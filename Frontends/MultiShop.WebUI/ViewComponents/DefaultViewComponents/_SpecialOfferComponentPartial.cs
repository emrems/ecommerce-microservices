using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.SpecialOfferDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _SpecialOfferComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClient;

        public _SpecialOfferComponentPartial(IHttpClientFactory client)
        {
            _httpClient = client;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {

            var client = _httpClient.CreateClient();
            var response = await client.GetAsync("https://localhost:7028/api/SpecialOffers");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();// json gelecek serialize etmek lazım
                var values = JsonConvert.DeserializeObject<List<ResultSpecialOfferDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
