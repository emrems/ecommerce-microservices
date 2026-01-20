using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.BasketServices;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;
using MultiShop.WebUI.Services.DiscountServices;

namespace MultiShop.WebUI.Controllers
{
    public class ShoppingCardController : Controller
    {
        private readonly IBasketService _basketService;
        private readonly IProductService _productService;
    
        public ShoppingCardController(IBasketService basketService, IProductService productService)
        {
            _basketService = basketService;
            _productService = productService;
           
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.directory1 = "Ana Sayfaa";
            ViewBag.directory2 = "Ürün Listesi";
            ViewBag.directory3 = "Sepetim";

            var values = await _basketService.GetBasket();
            ViewBag.total = values.TotalPrice;

            var totalPriceWithTax = values.TotalPrice + values.TotalPrice / 100 * 10;
            var tax= values.TotalPrice / 100 * 10;
            ViewBag.tax = tax;
            ViewBag.totalPriceWithTax = totalPriceWithTax;


            return View();
        }

        public async Task<IActionResult> AddToBasketItem(string id)
        {
            var product = await _productService.GetByIdProductAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            var newBasketTotalDto = new DtoLayer.BasketDtos.BasketItemDto
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                Price = product.ProductPrice,
                Quantity = 1,
                ProductImageUrl = product.ProductImageUrl

            };
            await _basketService.AddBasketItem(newBasketTotalDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> RemoveFromBasketItem(string id)
        {
            await _basketService.RemoveBasketItem(id);
            return RedirectToAction("Index");
        }
    }
}
