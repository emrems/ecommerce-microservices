using MultiShop.DtoLayer.IdentityDtos.LoginDtos;

namespace MultiShop.WebUI.Services.İnterfaces
{
    public interface IIdentityService
    {
        Task<bool> SignIn(SignInDto dto);
    }
}
