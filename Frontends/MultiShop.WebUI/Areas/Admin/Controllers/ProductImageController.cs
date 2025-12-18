using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using MultiShop.DtoLayer.CatalogDtos.ProductImageDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    
    [Area("Admin")]
    [AllowAnonymous]
    [Route("Admin/ProductImage")]
    public class ProductImageController : Controller
    {
        private readonly IHttpClientFactory _httpClient;

        public ProductImageController(IHttpClientFactory client)
        {
            _httpClient = client;
        }
        public async  Task<IActionResult> ProductImageDetail(string id)
        {
            return View();
        }

        [Route("ProductDetailImage/{id}")]
        [HttpGet]
        public async Task<IActionResult> ProductDetailImage(string id)
        {
            ViewBag.v1 = "Ana sayfa";
            ViewBag.v2 = "Ürünler";
            ViewBag.v3 = " Ürün foto güncelleme";
            ViewBag.v0 = "Ürün foto işlemleri";
            var client = _httpClient.CreateClient();
            var response = await client.GetAsync("https://localhost:7028/api/ProductImages/ProductImagesByProductId?id=" + id);
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateProductImageDto>(jsonData);
                return View(values);
            }
            return View();
        }

        [Route("ProductDetailImage/{id}")]
        [HttpPost]
        public async Task<IActionResult> ProductDetailImage(UpdateProductImageDto dto)
        {

            var client = _httpClient.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PutAsync("https://localhost:7028/api/ProductImages", stringContent);
            if (response.IsSuccessStatusCode)
            {

                return RedirectToAction("ProductListWithCategory", "Product", new { area = "Admin" });
            }
            return View();
        }
    }
}
