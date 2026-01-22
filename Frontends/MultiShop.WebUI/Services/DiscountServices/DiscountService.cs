using MultiShop.DtoLayer.DiscountDtos;

namespace MultiShop.WebUI.Services.DiscountServices
{
    public class DiscountService : IDiscountService
    {
        private readonly HttpClient _httpClient;

        public DiscountService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<GetDiscountDetailByCode> GetDiscountByCode(string code)
        {
            var response = await _httpClient.GetAsync($"Discounts/GetCodeDetailByCode/{code}");
            if (response.IsSuccessStatusCode)
            {
                var discount = await response.Content.ReadFromJsonAsync<GetDiscountDetailByCode>();
                return discount!;
            }
            return null!;
        }

        public async Task<int> GetDiscountCouponRate(string code)
        {
            
            var response = await _httpClient.GetAsync($"Discounts/GetDiscountCouponRate?code={code}");
            if (response.IsSuccessStatusCode)
            {
                var rate = await response.Content.ReadFromJsonAsync<int>();
                return rate;
            }
            return 0; 
        }
    }
}
