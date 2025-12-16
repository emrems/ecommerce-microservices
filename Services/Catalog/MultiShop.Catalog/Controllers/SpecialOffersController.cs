using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.SpecialOfferDtos;
using MultiShop.Catalog.Services.SpecialOfferService;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialOffersController : ControllerBase
    {
        private readonly ISpecialOfferService _specialOfferService;

        public SpecialOffersController(ISpecialOfferService specialOfferService)
        {
            _specialOfferService = specialOfferService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSpecialOffer()
        {
            var result = await _specialOfferService.GetAllSpecialOfferAsync();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSpecialOfferById(string id)
        {
            var result = await _specialOfferService.GetByIdSpecialOfferAsync(id);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateSpecialOffer(CreateSpecialOfferDto dto)
        {
            await _specialOfferService.CreateSpecialOfferAsync(dto);
            return Ok("özel teklif  başarılı bir şekilde eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteSpecialOfferById(string id)
        {
            await _specialOfferService.DeleteSpecialOfferAsync(id);
            return Ok("özel teklif  silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateSpecialOffer(UpdateSpecialOfferDto dto)
        {
            await _specialOfferService.UpdateSpecialOfferAsync(dto);
            return Ok("özel teklif güncellendi");
        }

    }
}
