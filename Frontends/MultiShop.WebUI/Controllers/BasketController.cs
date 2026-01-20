using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.BasketServices;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;

namespace MultiShop.WebUI.Controllers
{
    public class BasketController : Controller
    {
        //private readonly IBasketService _basketService;
        //private readonly IProductService _productService;
        //public BasketController(IBasketService basketService, IProductService productService)
        //{
        //    _basketService = basketService;
        //    _productService = productService;
        //}

        //public async Task<IActionResult>  Index()
        //{
        //    var values = await _basketService.GetBasket();

        //    return View(values);
        //}

        //public async Task<IActionResult> AddToBasket(string id)
        //{
        //    var product = await _productService.GetByIdProductAsync(id);
        //    if(product == null)
        //    {
        //        return NotFound();
        //    }
        //    var newBasketTotalDto = new DtoLayer.BasketDtos.BasketItemDto
        //    {
        //        ProductId = product.ProductId,
        //        ProductName = product.ProductName,
        //        Price = product.ProductPrice,
        //        Quantity = 1,

        //    };
        //    await _basketService.AddBasketItem(newBasketTotalDto);
        //    return RedirectToAction("Index");
        //}
    }
}
