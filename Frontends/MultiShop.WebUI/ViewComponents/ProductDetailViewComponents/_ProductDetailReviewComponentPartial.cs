using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using MultiShop.DtoLayer.CommentDtos;
using Newtonsoft.Json;
using System.Net.Http;

namespace MultiShop.WebUI.ViewComponents.ProductDetailViewComponents
{
   
    public class _ProductDetailReviewComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClient;
        public _ProductDetailReviewComponentPartial(IHttpClientFactory client)
        {
            _httpClient = client;
        }
        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var client = _httpClient.CreateClient();
            var response = await client.GetAsync(" https://localhost:7151/api/Comments/commentListByProductId?productId=" + id);
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();// json gelecek serialize etmek lazım
                var values = JsonConvert.DeserializeObject<List<ResultCommentDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
