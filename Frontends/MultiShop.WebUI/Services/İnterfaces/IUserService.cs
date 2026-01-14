using MultiShop.WebUI.Models;

namespace MultiShop.WebUI.Services.İnterfaces
{
    public interface IUserService
    {
        Task<UserDetailViewModel> GetUserInfo();
    }
}
