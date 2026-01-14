using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.IdentityDtos.LoginDtos;
using MultiShop.WebUI.Models;
using MultiShop.WebUI.Services.İnterfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text.Json;

namespace MultiShop.WebUI.Controllers
{
    public class LoginController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
      
        private readonly IIdentityService _identityService;

        public LoginController(IHttpClientFactory httpClientFactory, IIdentityService identityService)
        {
            _httpClientFactory = httpClientFactory;
           
            _identityService = identityService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(SignInDto dto)
        {
            await _identityService.SignIn(dto);
            return RedirectToAction("Index", "User");
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
        //public async Task<IActionResult> SignIn(SignInDto dto)

        //{
        //    dto.UserName = "emre";
        //    dto.Password = "Emre123.?emre";
        //    await _identityService.SignIn(dto);
        //    return RedirectToAction("Index", "User");
        //}
    }
}
