using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Discount.Dtos;
using MultiShop.Discount.Services;

namespace MultiShop.Discount.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountsController : ControllerBase
    {
        private readonly IDiscountService _service;

        public DiscountsController(IDiscountService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> CuponList()
        {
            var result = await _service.getAllCuponAsync();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> getCouponById(int id)
        {
            var result = await _service.getByIdCouponCode(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCoupon(CreateCouponDto dto)
        {
             await _service.CreateCuponAsync(dto);
            return Ok("kupon oluştu");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteKupon(int id)
        {
             await _service.DeleteCuponAsync(id);
            return Ok("kupon silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCoupon(UpdateCouponDto dto)
        {
            await _service.UpdateCuponAsync(dto);
            return Ok("kupon güncellendi");
        }
    }
}
