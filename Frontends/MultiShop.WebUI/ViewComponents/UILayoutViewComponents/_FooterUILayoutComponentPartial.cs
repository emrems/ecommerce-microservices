using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.AboutDtos;
using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using Newtonsoft.Json;
using System.Net.Http;

namespace MultiShop.WebUI.ViewComponents.UILayoutViewComponents
{
    public class _FooterUILayoutComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClient;
        public _FooterUILayoutComponentPartial(IHttpClientFactory client)
        {
            _httpClient = client;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClient.CreateClient();
            var response = await client.GetAsync("https://localhost:7028/api/Abouts");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();// json gelecek serialize etmek lazım
                var values = JsonConvert.DeserializeObject<List<ResultAboutDto>>(jsonData);
                return View(values);
            }
            return View();
        }
     }
}
