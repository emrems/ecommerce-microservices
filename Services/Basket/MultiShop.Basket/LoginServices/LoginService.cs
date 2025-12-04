namespace MultiShop.Basket.LoginServices
{
    public class LoginService : ILoginService
    {
        private readonly IHttpContextAccessor _acsessor;

        public LoginService(IHttpContextAccessor acsessor)
        {
            _acsessor = acsessor;
        }

        public string GetUserId => _acsessor.HttpContext.User.FindFirst("sub").Value;//token içinden alacak değer

    }
}
