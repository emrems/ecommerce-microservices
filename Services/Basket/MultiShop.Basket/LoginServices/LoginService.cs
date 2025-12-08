using System.Security.Claims;

namespace MultiShop.Basket.LoginServices
{
    public class LoginService : ILoginService
    {
        private readonly IHttpContextAccessor _acsessor;

        public LoginService(IHttpContextAccessor acsessor)
        {
            _acsessor = acsessor;
        }

        public string? GetUserId
        {
            get
            {
                var user = _acsessor?.HttpContext?.User;

                // Önce sub'a bak
                var subClaim = user?.FindFirst("sub");

                // Eğer yoksa NameIdentifier'a bak
                if (subClaim == null)
                {
                    subClaim = user?.FindFirst(ClaimTypes.NameIdentifier);
                }

                return subClaim?.Value;
            }
        }
    }
}
