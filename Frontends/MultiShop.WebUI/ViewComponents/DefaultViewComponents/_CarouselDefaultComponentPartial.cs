using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.FeatureSliderDtos;
using Newtonsoft.Json;
using System.Net.Http;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _CarouselDefaultComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClient;

        public _CarouselDefaultComponentPartial(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }

       
         
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClient.CreateClient();
            var response = await client.GetAsync("https://localhost:7028/api/FeatureSliders");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();// json gelecek serialize etmek lazım
                var values = JsonConvert.DeserializeObject<List<ResultFeatureSliderDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
