using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.FeatureDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    [Route("Admin/Feature")]
    public class FeatureController : Controller
    {
        private readonly IHttpClientFactory _httpClient;

        public FeatureController(IHttpClientFactory client)
        {
            _httpClient = client;
        }
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Ana sayfa";
            ViewBag.v2 = "Öne çıkan alanlar";
            ViewBag.v3 = "Öne çıkan alan listesi";
            ViewBag.v0 = "Öne çıkan alan işlemleri";
            var client = _httpClient.CreateClient();
            var response = await client.GetAsync("https://localhost:7028/api/Features");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();// json gelecek serialize etmek lazım
                var values = JsonConvert.DeserializeObject<List<ResultFeatureDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        [Route("CreateFeature")]
        public async Task<IActionResult> CreateFeature()
        {
            ViewBag.v1 = "Ana sayfa";
            ViewBag.v2 = "Öne çıkan alanlar";
            ViewBag.v3 = "Öne çıkan alan listesi";
            ViewBag.v0 = "Öne çıkan alan işlemleri";
            return View();
        }
        [HttpPost]
        [Route("CreateFeature")]
        public async Task<IActionResult> CreateFeature(CreateFeatureDto dto)
        {
            var client = _httpClient.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7028/api/Features", stringContent);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Feature", new { area = "Admin" });
            }
            return View();
        }


        [Route("DeleteFeature/{id}")]
        public async Task<IActionResult> DeleteFeature(string id)
        {
            var client = _httpClient.CreateClient();
            var response = await client.DeleteAsync("https://localhost:7028/api/Features?id=" + id);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Feature", new { area = "Admin" });
            }
            return View();
        }

        [Route("UpdateFeature/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateFeature(string id)
        {
            ViewBag.v1 = "Ana sayfa";
            ViewBag.v2 = "Öne çıkan alanlar";
            ViewBag.v3 = "Öne çıkan alan listesi";
            ViewBag.v0 = "Öne çıkan alan işlemleri";
            var client = _httpClient.CreateClient();
            var response = await client.GetAsync("https://localhost:7028/api/Features/" + id);
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateFeatureDto>(jsonData);
                return View(values);
            }
            return View();
        }

        [Route("UpdateFeature/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateFeature(UpdateFeatureDto dto)
        {

            var client = _httpClient.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PutAsync("https://localhost:7028/api/Features/", stringContent);
            if (response.IsSuccessStatusCode)
            {

                return RedirectToAction("Index", "Feature", new { area = "Admin" });
            }
            return View();
        }
    }
}
