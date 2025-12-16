using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.BrandDtos;
using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Services.BrandService;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandService _brandService;

        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBrands()
        {
            var brands = await _brandService.GetAllBrandAsync();
            return Ok(brands);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetBrandById(string id)
        {
            var brand = await _brandService.GetByIdBrandAsync(id);
            if (brand == null)
            {
                return NotFound();
            }
            return Ok(brand);
        }
        [HttpPost]
        public async Task<IActionResult> CreateBrand(CreateBrandDto dto)
        {
            await _brandService.CreateBrandAsync(dto);
            return Ok("marka başarılı bir şekilde eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteBrandById(string id)
        {
            await _brandService.DeleteBrandAsync(id);
            return Ok("marka silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBrand(UpdateBrandDto dto)
        {
            await _brandService.UpdateBrandAsync(dto);
            return Ok("marka güncellendi");
        }
    }
    }
