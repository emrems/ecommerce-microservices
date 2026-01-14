using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.AboutDtos;
using MultiShop.WebUI.Services.CatalogServices.AboutServices;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    [Route("Admin/About")]
    public class AboutController : Controller
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Ana sayfa";
            ViewBag.v2 = "Hakkımızda";
            ViewBag.v3 = "Hakkımızda listesi";
            ViewBag.v0 = "Hakkımızda işlemleri";
            
            var values = await _aboutService.GetAllAboutAsync();
            return View(values);
        }

        [HttpGet]
        [Route("CreateAbout")]
        public async Task<IActionResult> CreateAbout()
        {
            ViewBag.v1 = "Ana sayfa";
            ViewBag.v2 = "Hakkımızda";
            ViewBag.v3 = "Hakkımızda listesi";
            ViewBag.v0 = "Hakkımızda işlemleri";
            return View();
        }
        [HttpPost]
        [Route("CreateAbout")]
        public async Task<IActionResult> CreateAbout(CreateAboutDto dto)
        {
            
            await _aboutService.CreateAboutAsync(dto);
            return RedirectToAction("Index", "About", new { area = "Admin" });
        }


        [Route("DeleteAbout/{id}")]
        public async Task<IActionResult> DeleteAbout(string id)
        {
            
            await _aboutService.DeleteAboutAsync(id);
            return RedirectToAction("Index", "About", new { area = "Admin" });
        }

        [Route("UpdateAbout/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateAbout(string id)
        {
            ViewBag.v1 = "Ana sayfa";
            ViewBag.v2 = "Hakkımızda";
            ViewBag.v3 = "Hakkımızda listesi";
            ViewBag.v0 = "Hakkımızda işlemleri";
            
            var values = await _aboutService.GetByIdAboutAsync(id);
            return View(values);
        }

        [Route("UpdateAbout/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateAbout(UpdateAboutDto dto)
        {

            
            await _aboutService.UpdateAboutAsync(dto);
            return RedirectToAction("Index", "About", new { area = "Admin" });
        }
    }
}
