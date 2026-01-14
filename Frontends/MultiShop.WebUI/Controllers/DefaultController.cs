using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            var user = User.Claims;
            int x;
            ViewBag.directory1 = "Ana Sayfaa";
            ViewBag.directory2 = "Ürün Listesi";
            return View();
        }
    }
}
