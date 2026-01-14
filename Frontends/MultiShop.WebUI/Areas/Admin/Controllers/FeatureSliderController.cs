using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.FeatureSliderDtos;
using MultiShop.WebUI.Services.CatalogServices.FeatureSliderServices;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
   
    [Route("Admin/FeatureSlider")]
    public class FeatureSliderController : Controller
    {
        private readonly IFutureSliderService _futureSliderService;

        public FeatureSliderController(IFutureSliderService futureSliderService)
        {
            _futureSliderService = futureSliderService;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Ana sayfa";
            ViewBag.v2 = "Öne çıkan görseller";
            ViewBag.v3 = "Slider öne çıkan listesi";
            ViewBag.v0 = "Slider öne çıkan işlemleri";
           
            var values = await _futureSliderService.GetAllFeatureSliderAsync();
            return View(values);
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
            
            await _futureSliderService.CreateFeatureSliderAsync(dto);
            return RedirectToAction("Index", "FeatureSlider", new { area = "Admin" });
        }


        [Route("DeleteFeatureSlider/{id}")]
        public async Task<IActionResult> DeleteFeatureSlider(string id)
        {
            
            await _futureSliderService.DeleteFeatureSliderAsync(id);
            return RedirectToAction("Index", "FeatureSlider", new { area = "Admin" });
        }

        [Route("UpdateFeatureSlider/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateFeatureSlider(string id)
        {
            ViewBag.v1 = "Ana sayfa";
            ViewBag.v2 = "Öne çıkan görseller";
            ViewBag.v3 = "Slider öne çıkan listesi";
            ViewBag.v0 = "Slider öne çıkan işlemleri";
           
            var values = await _futureSliderService.GetByIdFeatureSliderAsync(id);
            return View(values);

        }

        [Route("UpdateFeatureSlider/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateFeatureSlider(UpdateFeatureSliderDto dto)
        {

           
            await _futureSliderService.UpdateFeatureSliderAsync(dto);
            return RedirectToAction("Index", "FeatureSlider", new { area = "Admin" });
        }
    }
}

