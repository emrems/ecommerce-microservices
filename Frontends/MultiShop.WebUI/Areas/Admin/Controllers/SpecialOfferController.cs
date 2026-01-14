using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.SpecialOfferDtos;
using MultiShop.WebUI.Services.CatalogServices.SpecialOfferServices;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
   
    [Route("Admin/SpecialOffer")]
    public class SpecialOfferController : Controller
    {
        private readonly ISpecialOfferService _specialOfferService;

        public SpecialOfferController(ISpecialOfferService specialOfferService)
        {
            _specialOfferService = specialOfferService;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Ana sayfa";
            ViewBag.v2 = "özel teklifler";
            ViewBag.v3 = "özel teklif ve günün indirimleri teklif listesi";
            ViewBag.v0 = "özel teklif işlemleri";
            var values = await _specialOfferService.GetAllSpecialOfferAsync();
            return View(values);
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
            
            await _specialOfferService.CreateSpecialOfferAsync(dto);
            return RedirectToAction("Index", "SpecialOffer", new { area = "Admin" });
        }


        [Route("DeleteSpecialOffer/{id}")]
        public async Task<IActionResult> DeleteSpecialOffer(string id)
        {
            

            await _specialOfferService.DeleteSpecialOfferAsync(id);
            return RedirectToAction("Index", "SpecialOffer", new { area = "Admin" });
        }

        [Route("UpdateSpecialOffer/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateSpecialOffer(string id)
        {
            ViewBag.v1 = "Ana sayfa";
            ViewBag.v2 = "özel teklifler";
            ViewBag.v3 = "özel teklif ve günün indirimleri teklif listesi";
            ViewBag.v0 = "özel teklif işlemleri";
            
            var values = await _specialOfferService.GetByIdSpecialOfferAsync(id);
            return View(values);

        }

        [Route("UpdateSpecialOffer/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateSpecialOffer(UpdateSpecialOfferDto dto)
        {

           
            await _specialOfferService.UpdateSpecialOfferAsync(dto);
            return RedirectToAction("Index", "SpecialOffer", new { area = "Admin" });
        }
    }
}
