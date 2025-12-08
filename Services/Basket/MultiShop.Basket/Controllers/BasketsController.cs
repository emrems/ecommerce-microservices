using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Basket.Dtos;
using MultiShop.Basket.LoginServices;
using MultiShop.Basket.Services;

namespace MultiShop.Basket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketsController : ControllerBase
    {
        private readonly IBasketService _service;
        private readonly ILoginService _loginService;

        public BasketsController(IBasketService service, ILoginService loginService)
        {
            _service = service;
            _loginService = loginService;
        }

        [HttpGet]
        public async Task<IActionResult> GetBasketAll()
        {
            var user = User.Claims;//token içindeki claimleri getirir
            var userId =  _loginService.GetUserId;
            var basket= await _service.GetBasket(userId);
            return Ok(basket);
        }

        [HttpPost]
        public async Task<IActionResult> SaveBasket(BasketTotalDto dto)
        {
            dto.UserId = _loginService.GetUserId;
            await _service.SaveBasket(dto);
            return Ok("sepet kaydedildi");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBasket()
        {
            var userId = _loginService.GetUserId;
            await _service.DeleteBasket(userId);
            return Ok("başarılıyla silindi");
        }
    }
}
