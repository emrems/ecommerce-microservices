using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.FeatureDtos;
using MultiShop.WebUI.Services.CatalogServices.FeatureServices;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
  
    [Route("Admin/Feature")]
    public class FeatureController : Controller
    {
        private readonly IFeatureService _featureService;

        public FeatureController(IFeatureService featureService)
        {
            _featureService = featureService;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Ana sayfa";
            ViewBag.v2 = "Öne çıkan alanlar";
            ViewBag.v3 = "Öne çıkan alan listesi";
            ViewBag.v0 = "Öne çıkan alan işlemleri";
           
            var values = await _featureService.GetAllFeatureAsync();
            return View(values);
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
            
           await _featureService.CreateFeatureAsync(dto);
            
           return RedirectToAction("Index", "Feature", new { area = "Admin" });
         
        }


        [Route("DeleteFeature/{id}")]
        public async Task<IActionResult> DeleteFeature(string id)
        {
            
            await _featureService.DeleteFeatureAsync(id);
            return RedirectToAction("Index", "Feature", new { area = "Admin" });
        }

        [Route("UpdateFeature/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateFeature(string id)
        {
            ViewBag.v1 = "Ana sayfa";
            ViewBag.v2 = "Öne çıkan alanlar";
            ViewBag.v3 = "Öne çıkan alan listesi";
            ViewBag.v0 = "Öne çıkan alan işlemleri";
            
            var value = await _featureService.GetByIdFeatureAsync(id);
            return View(value);
        }

        [Route("UpdateFeature/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateFeature(UpdateFeatureDto dto)
        {

            
            await _featureService.UpdateFeatureAsync(dto);
            return RedirectToAction("Index", "Feature", new { area = "Admin" });
        }
    }
}
