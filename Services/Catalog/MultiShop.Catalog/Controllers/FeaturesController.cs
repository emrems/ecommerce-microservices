using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.FeatureDtos;
using MultiShop.Catalog.Services.FeatureService;

namespace MultiShop.Catalog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesController : ControllerBase
    {
        private readonly IFeatureService _featureService;

        public FeaturesController(IFeatureService featureService)
        {
            _featureService = featureService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFeature()
        {
            var result = await _featureService.GetAllFeatureAsync();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFeatureById(string id)
        {
            var result = await _featureService.GetByIdFeatureAsync(id);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateFeature(CreateFeatureDto dto)
        {
            await _featureService.CreateFeatureAsync(dto);
            return Ok("öne çıkan alan başarılı bir şekilde eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteFeatureById(string id)
        {
            await _featureService.DeleteFeatureAsync(id);
            return Ok("öne çıkan alan silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateFeature(UpdateFeatureDto dto)
        {
            await _featureService.UpdateFeatureAsync(dto);
            return Ok("öne çıkan alan güncellendi");
        }
    }
}
