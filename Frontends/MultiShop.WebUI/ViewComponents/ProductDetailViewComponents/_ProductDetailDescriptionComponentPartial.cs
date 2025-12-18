using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ProductDetailDtos;
using Newtonsoft.Json;
using System.Net.Http;

namespace MultiShop.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class _ProductDetailDescriptionComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClient;
        public _ProductDetailDescriptionComponentPartial(IHttpClientFactory client)
        {
            _httpClient = client;
        }
        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var client = _httpClient.CreateClient();
            var response = await client.GetAsync($"https://localhost:7028/api/ProductDetails/GetProductDetailByProductId?id={id}");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateProductDetailDto>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
