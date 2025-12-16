using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.OfferDiscountDtos;
using MultiShop.Catalog.Services.OfferDiscountService;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfferDiscountsController : ControllerBase
    {
        private readonly IOfferDiscountService _offerDiscountService;
        public OfferDiscountsController(IOfferDiscountService offerDiscountService)
        {
            _offerDiscountService = offerDiscountService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOfferDiscount()
        {
            var result = await _offerDiscountService.GetAllOfferDiscountAsync();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOfferDiscountById(string id)
        {
            var result = await _offerDiscountService.GetByIdOfferDiscountAsync(id);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateOfferDiscount(CreateDiscountOfferDto dto)
        {
            await _offerDiscountService.CreateOfferDiscountAsync(dto);
            return Ok("özel teklif başarılı bir şekilde eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteOfferDiscountById(string id)
        {
            await _offerDiscountService.DeleteOfferDiscountAsync(id);
            return Ok("özel teklif silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateOfferDiscount(UpdateOfferDiscountOfferDto dto)
        {
            await _offerDiscountService.UpdateOfferDiscountAsync(dto);
            return Ok("özel teklif güncellendi");
        }
    }

    }
