using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.SpecialOfferDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    [Route("Admin/SpecialOffer")]
    public class SpecialOfferController : Controller
    {
        private readonly IHttpClientFactory _httpClient;

        public SpecialOfferController(IHttpClientFactory client)
        {
            _httpClient = client;
        }
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Ana sayfa";
            ViewBag.v2 = "özel teklifler";
            ViewBag.v3 = "özel teklif ve günün indirimleri teklif listesi";
            ViewBag.v0 = "özel teklif işlemleri";
            var client = _httpClient.CreateClient();
            var response = await client.GetAsync("https://localhost:7028/api/SpecialOffers");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();// json gelecek serialize etmek lazım
                var values = JsonConvert.DeserializeObject<List<ResultSpecialOfferDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        [Route("CreateSpecialOffer")]
        public async Task<IActionResult> CreateSpecialOffer()
        {
            ViewBag.v1 = "Ana sayfa";
            ViewBag.v2 = "özel teklifler";
            ViewBag.v3 = "özel teklif ve günün indirimleri teklif listesi";
            ViewBag.v0 = "özel teklif işlemleri";
            return View();
        }
        [HttpPost]
        [Route("CreateSpecialOffer")]
        public async Task<IActionResult> CreateSpecialOffer(CreateSpecialOfferDto dto)
        {
            var client = _httpClient.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7028/api/SpecialOffers", stringContent);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "SpecialOffer", new { area = "Admin" });
            }
            return View();
        }


        [Route("DeleteSpecialOffer/{id}")]
        public async Task<IActionResult> DeleteSpecialOffer(string id)
        {
            var client = _httpClient.CreateClient();
            var response = await client.DeleteAsync("https://localhost:7028/api/SpecialOffers?id=" + id);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "SpecialOffer", new { area = "Admin" });
            }
            return View();
        }

        [Route("UpdateSpecialOffer/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateSpecialOffer(string id)
        {
            ViewBag.v1 = "Ana sayfa";
            ViewBag.v2 = "özel teklifler";
            ViewBag.v3 = "özel teklif ve günün indirimleri teklif listesi";
            ViewBag.v0 = "özel teklif işlemleri";
            var client = _httpClient.CreateClient();
            var response = await client.GetAsync("https://localhost:7028/api/SpecialOffers/" + id);
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateSpecialOfferDto>(jsonData);
                return View(values);
            }
            return View();
        }

        [Route("UpdateSpecialOffer/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateSpecialOffer(UpdateSpecialOfferDto dto)
        {

            var client = _httpClient.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PutAsync("https://localhost:7028/api/SpecialOffers/", stringContent);
            if (response.IsSuccessStatusCode)
            {

                return RedirectToAction("Index", "SpecialOffer", new { area = "Admin" });
            }
            return View();
        }
    }
}
