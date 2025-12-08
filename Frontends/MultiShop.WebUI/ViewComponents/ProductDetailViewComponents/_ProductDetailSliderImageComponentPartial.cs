using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class _ProductDetailSliderImageComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        } 
    }
}
