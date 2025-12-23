using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.IdentityDtos.LoginDtos;
using MultiShop.WebUI.Models;
using MultiShop.WebUI.Services;
using MultiShop.WebUI.Services.İnterfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text.Json;

namespace MultiShop.WebUI.Controllers
{
    public class LoginController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILoginService _loginService;
        private readonly IIdentityService _identityService;

        public LoginController(IHttpClientFactory httpClientFactory, ILoginService loginService, IIdentityService identityService)
        {
            _httpClientFactory = httpClientFactory;
            _loginService = loginService;
            _identityService = identityService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginDto dto)
        {

            var client = _httpClientFactory.CreateClient();

            var content = new StringContent(
                JsonSerializer.Serialize(dto),
                System.Text.Encoding.UTF8,
                "application/json"
            );

            var response = await client.PostAsync(
                "http://localhost:5001/api/Logins",
                content
            );

            if (!response.IsSuccessStatusCode)
                return View();

            var jsonData = await response.Content.ReadAsStringAsync();

            var tokenModel = JsonSerializer.Deserialize<JwtResponseModel>(
                jsonData,
                new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase }
            );

            if (tokenModel == null)
                return View();

            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(tokenModel.Token);

            var claims = jwtToken.Claims.ToList();

            // JWT’yi cookie içine koyuyoruz
            claims.Add(new Claim("multishoptoken", tokenModel.Token));

            var identity = new ClaimsIdentity(
                claims,
                CookieAuthenticationDefaults.AuthenticationScheme
            );

            var authProps = new AuthenticationProperties
            {
                IsPersistent = true,
                ExpiresUtc = DateTime.SpecifyKind(tokenModel.ExpireDate, DateTimeKind.Utc)
            };


            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(identity),
                authProps
            );
            var id = _loginService.GetUserId;
            return RedirectToAction("Index", "Default");
        }

        //public async Task<IActionResult> Logout()
        //{
        //    await HttpContext.SignOutAsync(
        //        CookieAuthenticationDefaults.AuthenticationScheme
        //    );

        //    return RedirectToAction("Index", "Login");
        //}

        //[HttpGet]
        //public IActionResult SignIn()
        //{
        //    return View();
        //}

        //[HttpPost]
        public async Task<IActionResult> SignIn(SignInDto dto)
        
        {
            dto.UserName = "emre";
            dto.Password = "Emre123.?emre";
            var result = await _identityService.SignIn(dto);
            if (result)
                return RedirectToAction("Index", "Test");
            return View();
        }
    }
}
