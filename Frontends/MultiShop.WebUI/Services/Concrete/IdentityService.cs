using Duende.IdentityModel.Client;
using Humanizer;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using MultiShop.DtoLayer.IdentityDtos.LoginDtos;
using MultiShop.WebUI.Services.İnterfaces;
using MultiShop.WebUI.Settings;
using System.Security.Claims;
using System.Security.Principal;

namespace MultiShop.WebUI.Services.Concrete
{
    public class IdentityService : IIdentityService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ClientSetings _clientSetings;
        private readonly ServiceApiSettings _serviceApiSettings;
        public IdentityService(HttpClient httpClient, IHttpContextAccessor httpContextAccessor, IOptions<ClientSetings> clientSetings, IOptions<ServiceApiSettings> serviceApiSettings)
        {
            _httpClient = httpClient;
            _httpContextAccessor = httpContextAccessor;
            _clientSetings = clientSetings.Value;
            _serviceApiSettings = serviceApiSettings.Value;
        }

        public async Task<bool> GetRefreshToken()
        {
            var discoveryEndpoint = await _httpClient.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest
            {
                Address = _serviceApiSettings.IdentityServerUrl,
                Policy =
                {
                    RequireHttps = false
                }
            });

           

            var refreshToken = await _httpContextAccessor.HttpContext.GetTokenAsync(OpenIdConnectParameterNames.RefreshToken);

           RefreshTokenRequest refreshTokenRequest = new RefreshTokenRequest
            {
                Address = discoveryEndpoint.TokenEndpoint,
                ClientId = _clientSetings.MultiShopManagerClient.ClientId,
                ClientSecret = _clientSetings.MultiShopManagerClient.ClientSecret,
                RefreshToken = refreshToken
            };
            var token = await _httpClient.RequestRefreshTokenAsync(refreshTokenRequest);

            var authenticationToken = new List<AuthenticationToken>()
            {
                  new AuthenticationToken
                {
                    Name = OpenIdConnectParameterNames.AccessToken,
                    Value = token.AccessToken

                },
                new AuthenticationToken
                {
                    Name = OpenIdConnectParameterNames.RefreshToken,
                    Value = token.RefreshToken
                },
                new AuthenticationToken
                {
                    Name = OpenIdConnectParameterNames.ExpiresIn,
                    Value = DateTime.Now.AddSeconds(token.ExpiresIn).ToString()
                }

            };

            var result = await _httpContextAccessor.HttpContext.AuthenticateAsync();//tekrar oturum açma işlemi
            result.Properties.StoreTokens(authenticationToken);
            await _httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, result.Principal, result.Properties);


            return true;
        }

        public async Task<bool> SignIn(SignInDto dto)
        {
            var discoveryEndpoint = await _httpClient.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest
            {
                Address = _serviceApiSettings.IdentityServerUrl,
                Policy =
                {
                    RequireHttps = false
                }
            });

            var passwordTokenRequest = new PasswordTokenRequest
            {
                Address = discoveryEndpoint.TokenEndpoint,
                ClientId = _clientSetings.MultiShopManagerClient.ClientId,
                ClientSecret = _clientSetings.MultiShopManagerClient.ClientSecret,
                UserName = dto.UserName,
                Password = dto.Password,
               // Scope = "MultiShopAPI"
            };

            var token = await _httpClient.RequestPasswordTokenAsync(passwordTokenRequest); 

            var userInfoRequest = new UserInfoRequest
            {
                Address = discoveryEndpoint.UserInfoEndpoint,
                Token = token.AccessToken
            };

            var userValues = await _httpClient.GetUserInfoAsync(userInfoRequest);

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(userValues.Claims, CookieAuthenticationDefaults.AuthenticationScheme, "name", "role");

            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            var authenticationProperties = new AuthenticationProperties();

            authenticationProperties.StoreTokens(new List<AuthenticationToken>()
            {
                new AuthenticationToken
                {
                    Name = OpenIdConnectParameterNames.AccessToken,
                    Value = token.AccessToken

                },
                new AuthenticationToken
                {
                    Name = OpenIdConnectParameterNames.RefreshToken,
                    Value = token.RefreshToken
                },
                new AuthenticationToken
                {
                    Name = OpenIdConnectParameterNames.ExpiresIn,
                    Value = DateTime.Now.AddSeconds(token.ExpiresIn).ToString()
                }
            });

            authenticationProperties.IsPersistent = false;
            await _httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal, authenticationProperties);
            return true; 

        }
    }
}
