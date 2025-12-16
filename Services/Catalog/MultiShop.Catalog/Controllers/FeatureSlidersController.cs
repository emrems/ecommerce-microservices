using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.FeatureSliderDtos;
using MultiShop.Catalog.Services.FeatureSliderService;

namespace MultiShop.Catalog.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureSlidersController : ControllerBase
    {
        private readonly IFeatureSliderService _featureSliderService;

        public FeatureSlidersController(IFeatureSliderService featureSliderService)
        {
            _featureSliderService = featureSliderService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFeatureSlider()
        {
            var result = await _featureSliderService.GetAllFeatureSliderAsync();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFeatureSliderById(string id)
        {
            var result = await _featureSliderService.GetByIdFeatureSliderAsync(id);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateFeatureSlider(CreateFeatureSliderDto dto)
        {
            await _featureSliderService.CreateFeatureSliderAsync(dto);
            return Ok("slider başarılı bir şekilde eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteFeatureSliderById(string id)
        {
            await _featureSliderService.DeleteFeatureSliderAsync(id);
            return Ok("slider silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateFeatureSlider(UpdateFeatureSliderDto dto)
        {
            await _featureSliderService.UpdateFeatureSliderAsync(dto);
            return Ok("slider güncellendi");
        }
    }
}
