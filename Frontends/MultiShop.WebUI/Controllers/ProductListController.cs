using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CommentDtos;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace MultiShop.WebUI.Controllers
{
    public class ProductListController : Controller
    {
        private readonly IHttpClientFactory _httpClient;
        public ProductListController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory;
        }
        public IActionResult Index(string id)
        {
            ViewBag.i = id;
            return View();
        }
        public IActionResult ProductDetail(string id)
        {
            ViewBag.x = id;
            return View();
        }

        [HttpGet]
        public PartialViewResult AddComment()
        {
           
            return PartialView();
          
           
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(CreateCommentDto dto)
        {
            dto.ImageUrl = "test";
            dto.Rating = 1;
            dto.CreatedDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            dto.Status = false;
            dto.ProductId = "69416695796d6da414fc2a98"; 
            var client = _httpClient.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7151/api/Comments", stringContent);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Default");
            }
            return View();
        }
    }
}
