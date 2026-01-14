using Duende.IdentityModel.Client;
using Microsoft.Extensions.Options;
using MultiShop.WebUI.Services.İnterfaces;
using MultiShop.WebUI.Settings;

public class ClientCredentialTokenService : IClientCredentialTokenService
{
    private readonly HttpClient _httpClient;
    private readonly ServiceApiSettings _apiSettings;
    private readonly ClientSetings _clientSettings;

    private string _accessToken;
    private DateTime _expiresAt;

    public ClientCredentialTokenService(
        HttpClient httpClient,
        IOptions<ServiceApiSettings> apiSettings,
        IOptions<ClientSetings> clientSettings)
    {
        _httpClient = httpClient;
        _apiSettings = apiSettings.Value;
        _clientSettings = clientSettings.Value;
    }

    public async Task<string> GetToken()
    {
        if (!string.IsNullOrEmpty(_accessToken) && _expiresAt > DateTime.UtcNow)
            return _accessToken;

        var disco = await _httpClient.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest
        {
            Address = _apiSettings.IdentityServerUrl,
            Policy = { RequireHttps = false }
        });

        var tokenResponse = await _httpClient.RequestClientCredentialsTokenAsync(
            new ClientCredentialsTokenRequest
            {
                Address = disco.TokenEndpoint,
                ClientId = _clientSettings.MultiShopVisitorClient.ClientId,
                ClientSecret = _clientSettings.MultiShopVisitorClient.ClientSecret
            });

        _accessToken = tokenResponse.AccessToken;
        _expiresAt = DateTime.UtcNow.AddSeconds(tokenResponse.ExpiresIn - 60);

        return _accessToken;
    }
}
