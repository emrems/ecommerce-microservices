using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Services.CategoryServices;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var result = await _categoryService.GetAllCategoryAsync();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoriesById(string id)
        {
            var result = await _categoryService.GetByIdCategoryAsync(id);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategories(CreateCategoryDto dto)
        {
          await _categoryService.CreateCategoryAsync(dto);
            return Ok("kategori başarılı bir şekilde eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCategoriesById(string id)
        {
            await _categoryService.DeleteCategoryAsync(id);
            return Ok("category silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCategories(UpdateCategoryDto dto)
        {
            await _categoryService.UpdateCategoryAsync(dto);
            return Ok("category güncellendi");
        }


    }
}
