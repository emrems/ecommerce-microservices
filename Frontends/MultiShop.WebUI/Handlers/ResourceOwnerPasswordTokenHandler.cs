using Microsoft.AspNetCore.Authentication;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using MultiShop.WebUI.Services.İnterfaces;
using System.Net;
using System.Net.Http.Headers;

namespace MultiShop.WebUI.Handlers
{
    // bu sınıf userSerivce için token ayarlamalarını yapacak
    public class ResourceOwnerPasswordTokenHandler : DelegatingHandler
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IIdentityService _identityService;

        public ResourceOwnerPasswordTokenHandler(IHttpContextAccessor httpContextAccessor, IIdentityService identityService)
        {
            _httpContextAccessor = httpContextAccessor;
            _identityService = identityService;
        }

        override protected async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            //giriş yapan kullanıcının access token ını al
            var accessToken = await _httpContextAccessor.HttpContext.GetTokenAsync(OpenIdConnectParameterNames.AccessToken);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var response = await base.SendAsync(request, cancellationToken);
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                //access token süresi dolmuş ise refresh token ile yeni access token al
                var newToken = await _identityService.GetRefreshToken();
                if (newToken != null)
                {
                    //yeni access token ile isteği tekrarla
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                    response = await base.SendAsync(request, cancellationToken);
                    return response;
                }
            }
            if(response.StatusCode == HttpStatusCode.Unauthorized)
            {
                //yeni token ile de yetkisiz ise kullanıcıyı login sayfasına yönlendir
                //_httpContextAccessor.HttpContext.Response.Redirect("/Auth/SignIn");
                //return response;
            }

            return response;
        }
    }
}
