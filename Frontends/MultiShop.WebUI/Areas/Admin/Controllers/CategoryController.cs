using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using MultiShop.WebUI.Services.CatalogServices.CategoryServices;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Category")]
    public class CategoryController : Controller
    {
        private readonly IHttpClientFactory _httpClient;
        private readonly ICategoryService _categoryService;

        public CategoryController(IHttpClientFactory client, ICategoryService categoryService)
        {
            _httpClient = client;
            _categoryService = categoryService;
        }
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Ana sayfa";
            ViewBag.v2 = "Kategoriler";
            ViewBag.v3 = "Kategori listesi";
            ViewBag.v0 = "Kategori işlemleri";
            var values = await _categoryService.GetAllCategoryAsync();
            return View(values);

            
        }

        [HttpGet]
        [Route("CreateCategory")]
        public async Task<IActionResult> CreateCategory()
        {
            ViewBag.v1 = "Ana sayfa";
            ViewBag.v2 = "Kategoriler";
            ViewBag.v3 = "Yeni Kategori girişi";
            ViewBag.v0 = "Kategori işlemleri";
            return View();
        }
        [HttpPost]
        [Route("CreateCategory")]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto dto)
        {
             await _categoryService.CreateCategoryAsync(dto);
             return RedirectToAction("Index", "Category", new { area = "Admin" });
           
        }

       
        [Route("DeleteCategory/{id}")]
        public async Task<IActionResult> DeleteCategory(string id)
        {
            await _categoryService.DeleteCategoryAsync(id);
            return RedirectToAction("Index", "Category", new { area = "Admin" });
         
        }

        [Route("UpdateCategory/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateCategory(string id)
        {
            ViewBag.v1 = "Ana sayfa";
            ViewBag.v2 = "Kategoriler";
            ViewBag.v3 = " Kategori güncelleme";
            ViewBag.v0 = "Kategori işlemleri";
            var value = await _categoryService.GetByIdCategoryAsync(id);
            return View(value);
        }

        [Route("UpdateCategory/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto dto)
        {
            
            await _categoryService.UpdateCategoryAsync(dto);
            return RedirectToAction("Index", "Category", new { area = "Admin" });
        }
    }
}
