using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using MultiShop.WebUI.Services.CatalogServices.CategoryServices;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Route("Admin/Product")]
    public class ProductController : Controller
    {

       
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        public ProductController(IProductService productService, ICategoryService categoryService)
        {
          
            _productService = productService;
            _categoryService = categoryService;
        }
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Ana sayfa";
            ViewBag.v2 = "Ürünler";
            ViewBag.v3 = "Ürün listesi";
            ViewBag.v0 = "Ürün işlemleri";
            var values =await _productService.GetAllProductAsync();
            return View(values);
        }

        [Route("ProductListWithCategory")]
        public async Task<IActionResult> ProductListWithCategory()
        {
            var products =await _productService.getProductsWithCategoryAsync();
            return View(products);
        }

        [Route("CreateProduct")]
        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {
            ViewBag.v1 = "Ana sayfa";
            ViewBag.v2 = "Ürünler";
            ViewBag.v3 = "Ürün listesi";
            ViewBag.v0 = "Ürün işlemleri";
            var values = await _productService.GetAllProductAsync();

            var categories = await _categoryService.GetAllCategoryAsync();
            //var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
            List<SelectListItem> categoryValues = (from x in categories
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID
                                                   }).ToList();
            ViewBag.CategoryValues = categoryValues;
            return View();
        }

        [HttpPost]
        [Route("CreateProduct")]
        public async Task<IActionResult> CreateProduct(CreateProductDto dto)
        {
           await _productService.CreateProductAsync(dto);
            return RedirectToAction("Index", "Product", new { area = "Admin" });
        }

        [Route("DeleteProduct/{id}")]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            await _productService.DeleteProductAsync(id);
            return RedirectToAction("Index", "Product", new { area = "Admin" });
        }

        [Route("UpdateProduct/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateProduct(string id)
        {
            ViewBag.v1 = "Ana sayfa";
            ViewBag.v2 = "Ürünler";
            ViewBag.v3 = " Ürün güncelleme";
            ViewBag.v0 = "Ürün işlemleri";

            var values = await _productService.GetAllProductAsync();

            var categories = await _categoryService.GetAllCategoryAsync();
            //var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
            List<SelectListItem> categoryValues = (from x in categories
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID
                                                   }).ToList();
            ViewBag.CategoryValues = categoryValues;

            var productValue = await _productService.GetByIdProductAsync(id);
            return View(productValue);
        }

        [Route("UpdateProduct/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto dto)
        {

           await _productService.UpdateProductAsync(dto);
            return RedirectToAction("Index", "Product", new { area = "Admin" });
        }
    }
}
