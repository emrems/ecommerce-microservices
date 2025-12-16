using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.FeatureSliderDtos;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    [Route("Admin/FeatureSlider")]
    public class FeatureSliderController : Controller
    {
        private readonly IHttpClientFactory _httpClient;

        public FeatureSliderController(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }

        
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Ana sayfa";
            ViewBag.v2 = "Öne çıkan görseller";
            ViewBag.v3 = "Slider öne çıkan listesi";
            ViewBag.v0 = "Slider öne çıkan işlemleri";
            var client = _httpClient.CreateClient();
            var response = await client.GetAsync("https://localhost:7028/api/FeatureSliders");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();// json gelecek serialize etmek lazım
                var values = JsonConvert.DeserializeObject<List<ResultFeatureSliderDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        [Route("CreateFeatureSlider")]
        public async Task<IActionResult> CreateFeatureSlider()
        {
            ViewBag.v1 = "Ana sayfa";
            ViewBag.v2 = "Öne çıkan görseller";
            ViewBag.v3 = "Slider öne çıkan listesi";
            ViewBag.v0 = "Slider öne çıkan işlemleri";
            return View();
        }

        [HttpPost]
        [Route("CreateFeatureSlider")]
        public async Task<IActionResult> CreateFeatureSlider(CreateFeatureSliderDto dto)
        {
            dto.Status = false;
            var client = _httpClient.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7028/api/FeatureSliders", stringContent);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "FeatureSlider", new { area = "Admin" });
            }
            return View();
        }


        [Route("DeleteFeatureSlider/{id}")]
        public async Task<IActionResult> DeleteFeatureSlider(string id)
        {
            var client = _httpClient.CreateClient();
            var response = await client.DeleteAsync("https://localhost:7028/api/FeatureSliders?id=" + id);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "FeatureSlider", new { area = "Admin" });
            }
            return View();
        }

        [Route("UpdateFeatureSlider/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateFeatureSlider(string id)
        {
            ViewBag.v1 = "Ana sayfa";
            ViewBag.v2 = "Öne çıkan görseller";
            ViewBag.v3 = "Slider öne çıkan listesi";
            ViewBag.v0 = "Slider öne çıkan işlemleri";
            var client = _httpClient.CreateClient();
            var response = await client.GetAsync("https://localhost:7028/api/FeatureSliders/" + id);
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateFeatureSliderDto>(jsonData);
                return View(values);
            }
            return View();
        }

        [Route("UpdateFeatureSlider/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateFeatureSlider(UpdateFeatureSliderDto dto)
        {

            var client = _httpClient.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PutAsync("https://localhost:7028/api/FeatureSliders/", stringContent);
            if (response.IsSuccessStatusCode)
            {

                return RedirectToAction("Index", "FeatureSlider", new { area = "Admin" });
            }
            return View();
        }
    }
}

