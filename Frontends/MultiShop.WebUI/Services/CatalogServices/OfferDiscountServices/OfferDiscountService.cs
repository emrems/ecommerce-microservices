using MultiShop.DtoLayer.CatalogDtos.OfferDiscountDtos;
using MultiShop.DtoLayer.CatalogDtos.OfferDiscountDtos;

namespace MultiShop.WebUI.Services.CatalogServices.OfferDiscountServices
{
    public class OfferDiscountService : IOfferDiscountService
    {
        private readonly HttpClient _httpClient;

        public OfferDiscountService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateOfferDiscountAsync(CreateOfferDiscountDto dto)
        {

            await _httpClient.PostAsJsonAsync<CreateOfferDiscountDto>("OfferDiscounts", dto);

        }

        public async Task DeleteOfferDiscountAsync(string id)
        {

            await _httpClient.DeleteAsync($"OfferDiscounts?id={id}");
        }


        public async Task<List<ResultOfferDiscountDto>> GetAllOfferDiscountAsync()
        {

            var responseMessage = await _httpClient.GetAsync("OfferDiscounts");

            if (responseMessage.IsSuccessStatusCode)
            {
                return await responseMessage.Content.ReadFromJsonAsync<List<ResultOfferDiscountDto>>();
            }
            return new List<ResultOfferDiscountDto>();
        }


        public async Task<UpdateOfferDiscountDto> GetByIdOfferDiscountAsync(string id)
        {

            var responseMessage = await _httpClient.GetAsync($"OfferDiscounts/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<UpdateOfferDiscountDto>();
            return values;
        }

        public async Task UpdateOfferDiscountAsync(UpdateOfferDiscountDto dto)
        {

            await _httpClient.PutAsJsonAsync<UpdateOfferDiscountDto>("OfferDiscounts", dto);

        }
    }
}
