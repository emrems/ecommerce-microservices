namespace MultiShop.WebUI.Services.İnterfaces
{
    // şifre ve kullanıcı adı olmadan giriş yapma için token alma servisi
    public interface IClientCredentialTokenService
    {
        Task<string> GetToken();
    }
}
