using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.OfferDiscountDtos;
using MultiShop.WebUI.Services.CatalogServices.OfferDiscountServices;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
  
    [Route("Admin/OfferDiscount")]
    public class OfferDiscountController : Controller
    {
        private readonly IOfferDiscountService _offerDiscountService;

        public OfferDiscountController(IOfferDiscountService offerDiscountService)
        {
            _offerDiscountService = offerDiscountService;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Ana sayfa";
            ViewBag.v2 = "İndirim teklifler";
            ViewBag.v3 = "İndirim teklifler listesi";
            ViewBag.v0 = "İndirim teklifler işlemleri";
            
            var values = await _offerDiscountService.GetAllOfferDiscountAsync();
            return View(values);
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
            
            await _offerDiscountService.CreateOfferDiscountAsync(dto);
            return RedirectToAction("Index", "OfferDiscount", new { area = "Admin" });
        }


        [Route("DeleteOfferDiscount/{id}")]
        public async Task<IActionResult> DeleteOfferDiscount(string id)
        {
            
            await _offerDiscountService.DeleteOfferDiscountAsync(id);
            return RedirectToAction("Index", "OfferDiscount", new { area = "Admin" });
        }

        [Route("UpdateOfferDiscount/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateOfferDiscount(string id)
        {
            ViewBag.v1 = "Ana sayfa";
            ViewBag.v2 = "İndirim teklifler";
            ViewBag.v3 = "İndirim teklifler listesi";
            ViewBag.v0 = "İndirim teklifler işlemleri";
            
            var values = await _offerDiscountService.GetByIdOfferDiscountAsync(id);
            return View(values);
        }

        [Route("UpdateOfferDiscount/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateOfferDiscount(UpdateOfferDiscountDto dto)
        {

            
            await _offerDiscountService.UpdateOfferDiscountAsync(dto);
            return RedirectToAction("Index", "OfferDiscount", new { area = "Admin" });
        }
    }
}
