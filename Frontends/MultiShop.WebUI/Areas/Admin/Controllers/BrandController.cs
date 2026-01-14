using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.BrandDtos;
using MultiShop.WebUI.Services.CatalogServices.BrandServices;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    
    [Route("Admin/Brand")]
    public class BrandController : Controller
    {

        private readonly IBrandService _brandService;

        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Ana sayfa";
            ViewBag.v2 = "Markalar";
            ViewBag.v3 = "Markalar listesi";
            ViewBag.v0 = "Marka işlemleri";
            
            var values = await _brandService.GetAllBrandAsync();
            return View(values);
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
            
            await _brandService.CreateBrandAsync(dto);
            return RedirectToAction("Index", "Brand", new { area = "Admin" });
        }


        [Route("DeleteBrand/{id}")]
        public async Task<IActionResult> DeleteBrand(string id)
        {
            await _brandService.DeleteBrandAsync(id);
            return RedirectToAction("Index", "Brand", new { area = "Admin" });
        }

        [Route("UpdateBrand/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateBrand(string id)
        {
            ViewBag.v1 = "Ana sayfa";
            ViewBag.v2 = "Markalar";
            ViewBag.v3 = "Markalar listesi";
            ViewBag.v0 = "Marka işlemleri";
            
            var values = await _brandService.GetByIdBrandAsync(id);
            return View(values);
        }

        [Route("UpdateBrand/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateBrand(UpdateBrandDto dto)
        {

           
            await _brandService.UpdateBrandAsync(dto);
            return RedirectToAction("Index", "Brand", new { area = "Admin" });
        }
    }
}
