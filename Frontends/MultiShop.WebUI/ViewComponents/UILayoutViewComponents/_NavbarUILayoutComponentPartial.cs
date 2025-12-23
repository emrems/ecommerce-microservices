using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;

namespace MultiShop.WebUI.ViewComponents.UILayoutViewComponents
{
    public class _NavbarUILayoutComponentPartial :ViewComponent
    {
        private readonly IHttpClientFactory _httpClient;
        public _NavbarUILayoutComponentPartial(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {

            string token = "";
            using (var httpClient = _httpClient.CreateClient())
            {
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri("http://localhost:5001/connect/token"),
                    Content = new FormUrlEncodedContent(new Dictionary<string, string>
                    {
                        { "client_id", "MultiShopVisitorId" },
                        { "client_secret", "multishopsecret" },
                        { "grant_type", "client_credentials" },

                    })
                };
                using (var response1 = await httpClient.SendAsync(request))
                {
                    //response1.EnsureSuccessStatusCode();
                    if (response1.IsSuccessStatusCode)
                    {
                        var content = await response1.Content.ReadAsStringAsync();
                        var tokenResponse = JsonConvert.DeserializeObject<Dictionary<string, string>>(content);
                        token = tokenResponse["access_token"].ToString();
                    }
                }
            }
            var client = _httpClient.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await client.GetAsync("https://localhost:7028/api/Categories");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();// json gelecek serialize etmek lazım
                var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
