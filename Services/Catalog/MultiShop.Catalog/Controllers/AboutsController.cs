using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.AbaoutDtos;
using MultiShop.Catalog.Dtos.AbaoutDtos;
using MultiShop.Catalog.Services.AboutService;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController : ControllerBase
    {
        private readonly IAboutService _aboutService;
        public AboutsController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAbout()
        {
            var result = await _aboutService.GetAllAboutAsync();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAboutById(string id)
        {
            var result = await _aboutService.GetByIdAboutAsync(id);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAbout(CreateAboutDto dto)
        {
            await _aboutService.CreateAboutAsync(dto);
            return Ok("Hakkında  başarılı bir şekilde eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteAboutById(string id)
        {
            await _aboutService.DeleteAboutAsync(id);
            return Ok("Hakkında silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAbout(UpdateAboutDto dto)
        {
            await _aboutService.UpdateAboutAsync(dto);
            return Ok("Hakkında güncellendi");
        }

    }
}
