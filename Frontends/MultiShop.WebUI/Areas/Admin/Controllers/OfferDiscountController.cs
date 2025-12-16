using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.OfferDiscountDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    [Route("Admin/OfferDiscount")]
    public class OfferDiscountController : Controller
    {
        private readonly IHttpClientFactory _httpClient;

        public OfferDiscountController(IHttpClientFactory client)
        {
            _httpClient = client;
        }
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Ana sayfa";
            ViewBag.v2 = "İndirim teklifler";
            ViewBag.v3 = "İndirim teklifler listesi";
            ViewBag.v0 = "İndirim teklifler işlemleri";
            var client = _httpClient.CreateClient();
            var response = await client.GetAsync("https://localhost:7028/api/OfferDiscounts");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();// json gelecek serialize etmek lazım
                var values = JsonConvert.DeserializeObject<List<ResultOfferDiscountDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        [Route("CreateOfferDiscount")]
        public async Task<IActionResult> CreateOfferDiscount()
        {
            ViewBag.v1 = "Ana sayfa";
            ViewBag.v2 = "İndirim teklifler";
            ViewBag.v3 = "İndirim teklifler listesi";
            ViewBag.v0 = "İndirim teklifler işlemleri";
            return View();
        }
        [HttpPost]
        [Route("CreateOfferDiscount")]
        public async Task<IActionResult> CreateOfferDiscount(CreateOfferDiscountDto dto)
        {
            var client = _httpClient.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7028/api/OfferDiscounts", stringContent);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "OfferDiscount", new { area = "Admin" });
            }
            return View();
        }


        [Route("DeleteOfferDiscount/{id}")]
        public async Task<IActionResult> DeleteOfferDiscount(string id)
        {
            var client = _httpClient.CreateClient();
            var response = await client.DeleteAsync("https://localhost:7028/api/OfferDiscounts?id=" + id);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "OfferDiscount", new { area = "Admin" });
            }
            return View();
        }

        [Route("UpdateOfferDiscount/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateOfferDiscount(string id)
        {
            ViewBag.v1 = "Ana sayfa";
            ViewBag.v2 = "İndirim teklifler";
            ViewBag.v3 = "İndirim teklifler listesi";
            ViewBag.v0 = "İndirim teklifler işlemleri";
            var client = _httpClient.CreateClient();
            var response = await client.GetAsync($"https://localhost:7028/api/OfferDiscounts/{id}");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateOfferDiscountDto>(jsonData);
                return View(values);
            }
            return View();
        }

        [Route("UpdateOfferDiscount/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateOfferDiscount(UpdateOfferDiscountDto dto)
        {

            var client = _httpClient.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PutAsync("https://localhost:7028/api/OfferDiscounts", stringContent);
            if (response.IsSuccessStatusCode)
            {

                return RedirectToAction("Index", "OfferDiscount", new { area = "Admin" });
            }
            return View();
        }
    }
}
