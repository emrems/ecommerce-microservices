using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MultiShop.IdentityServer.Dtos;
using MultiShop.IdentityServer.Models;
using MultiShop.IdentityServer.Tools;
using System.Threading.Tasks;

namespace MultiShop.IdentityServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginsController : ControllerBase
    {
        private readonly SignInManager<ApplicationUser> _signInManager;

        public LoginsController(SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
        }

        [HttpPost]
        public async Task<IActionResult> UserLogin(UserLoginDto dto)
        {

            var result = await _signInManager.PasswordSignInAsync(dto.Username, dto.Password, false, false);
            if (result.Succeeded)
            {
                GetCheckAppUserViewModel model = new GetCheckAppUserViewModel();
                model.UserName = dto.Username;
                model.Id = (await _signInManager.UserManager.FindByNameAsync(dto.Username)).Id;
                var token = JwtTokenGenerator.GenerateToken(model);
                return Ok(token);


            }
            return Unauthorized("kullanıcı adı veya şifrea hatalı");
        }
          
    }
}
