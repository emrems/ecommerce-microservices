using MultiShop.DtoLayer.CatalogDtos.SpecialOfferDtos;
using MultiShop.DtoLayer.CatalogDtos.SpecialOfferDtos;
using System.Net.Http.Json;

namespace MultiShop.WebUI.Services.CatalogServices.SpecialOfferServices
{
    public class SpecialOfferService : ISpecialOfferService
    {
        private readonly HttpClient _httpClient;

        public SpecialOfferService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateSpecialOfferAsync(CreateSpecialOfferDto dto)
        {

            await _httpClient.PostAsJsonAsync<CreateSpecialOfferDto>("SpecialOffers", dto);

        }

        public async Task DeleteSpecialOfferAsync(string id)
        {

            await _httpClient.DeleteAsync($"SpecialOffers?id={id}");
        }


        public async Task<List<ResultSpecialOfferDto>> GetAllSpecialOfferAsync()
        {

            var responseMessage = await _httpClient.GetAsync("SpecialOffers");

            if (responseMessage.IsSuccessStatusCode)
            {
                return await responseMessage.Content.ReadFromJsonAsync<List<ResultSpecialOfferDto>>();
            }
            return new List<ResultSpecialOfferDto>();
        }


        public async Task<UpdateSpecialOfferDto> GetByIdSpecialOfferAsync(string id)
        {

            var responseMessage = await _httpClient.GetAsync($"SpecialOffers/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<UpdateSpecialOfferDto>();
            return values;
        }

        public async Task UpdateSpecialOfferAsync(UpdateSpecialOfferDto dto)
        {

            await _httpClient.PutAsJsonAsync<UpdateSpecialOfferDto>("SpecialOffers", dto);

        }

         
    }
}
