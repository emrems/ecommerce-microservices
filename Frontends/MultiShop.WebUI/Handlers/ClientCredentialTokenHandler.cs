using MultiShop.WebUI.Services.İnterfaces;
using System.Net.Http.Headers;

public class ClientCredentialTokenHandler : DelegatingHandler
{
    private readonly IClientCredentialTokenService _tokenService;

    public ClientCredentialTokenHandler(IClientCredentialTokenService tokenService)
    {
        _tokenService = tokenService;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var token = await _tokenService.GetToken();
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
        return await base.SendAsync(request, cancellationToken);
    }
}
