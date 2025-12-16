using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.BrandDtos;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    [Route("Admin/Brand")]
    public class BrandController : Controller
    {

        private readonly IHttpClientFactory _httpClient;

        public BrandController(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Ana sayfa";
            ViewBag.v2 = "Markalar";
            ViewBag.v3 = "Markalar listesi";
            ViewBag.v0 = "Marka işlemleri";
            var client = _httpClient.CreateClient();
            var response = await client.GetAsync("https://localhost:7028/api/Brands");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();// json gelecek serialize etmek lazım
                var values = JsonConvert.DeserializeObject<List<ResultBrandDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        [Route("CreateBrand")]
        public async Task<IActionResult> CreateBrand()
        {
            ViewBag.v1 = "Ana sayfa";
            ViewBag.v2 = "Markalar";
            ViewBag.v3 = "Markalar listesi";
            ViewBag.v0 = "Marka işlemleri";
            return View();
        }
        [HttpPost]
        [Route("CreateBrand")]
        public async Task<IActionResult> CreateBrand(CreateBrandDto dto)
        {
            var client = _httpClient.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7028/api/Brands", stringContent);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Brand", new { area = "Admin" });
            }
            return View();
        }


        [Route("DeleteBrand/{id}")]
        public async Task<IActionResult> DeleteBrand(string id)
        {
            var client = _httpClient.CreateClient();
            var response = await client.DeleteAsync("https://localhost:7028/api/Brands?id=" + id);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Brand", new { area = "Admin" });
            }
            return View();
        }

        [Route("UpdateBrand/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateBrand(string id)
        {
            ViewBag.v1 = "Ana sayfa";
            ViewBag.v2 = "Markalar";
            ViewBag.v3 = "Markalar listesi";
            ViewBag.v0 = "Marka işlemleri";
            var client = _httpClient.CreateClient();
            var response = await client.GetAsync($"https://localhost:7028/api/Brands/{id}");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateBrandDto>(jsonData);
                return View(values);
            }
            return View();
        }

        [Route("UpdateBrand/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateBrand(UpdateBrandDto dto)
        {

            var client = _httpClient.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PutAsync("https://localhost:7028/api/Brands", stringContent);
            if (response.IsSuccessStatusCode)
            {

                return RedirectToAction("Index", "Brand", new { area = "Admin" });
            }
            return View();
        }
    }
}
