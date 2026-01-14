using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using MultiShop.WebUI.Services.İnterfaces;
using System.Security.Claims;

namespace MultiShop.WebUI.Services.Concrete
{
    public class LoginService : ILoginService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LoginService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetUserId =>  
            _httpContextAccessor.HttpContext!.User.FindFirst(ClaimTypes.NameIdentifier).Value;
    }
}
