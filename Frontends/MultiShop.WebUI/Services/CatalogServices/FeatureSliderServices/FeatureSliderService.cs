using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using MultiShop.DtoLayer.CatalogDtos.FeatureSliderDtos;
using System.Net.Http.Json;

namespace MultiShop.WebUI.Services.CatalogServices.FeatureSliderServices
{
    public class FeatureSliderService : IFutureSliderService
    {
        private readonly HttpClient _httpClient;

        public FeatureSliderService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateFeatureSliderAsync(CreateFeatureSliderDto dto)
        {
           
            await _httpClient.PostAsJsonAsync<CreateFeatureSliderDto>("FeatureSliders", dto);

        }

        public async Task DeleteFeatureSliderAsync(string id)
        {

            await _httpClient.DeleteAsync($"FeatureSliders?id={id}");
        }

        public async Task FeatureSliderChangeStatusToFalse(string id)
        {
            
            await _httpClient.GetAsync($"FeatureSliders/ChangeStatusToFalse?id={id}");
        }

        public async Task FeatureSliderChangeStatusToTrue(string id)
        {
                
            await _httpClient.GetAsync($"FeatureSliders/ChangeStatusToTrue?id={id}");
        }

        public async Task<List<ResultFeatureSliderDto>> GetAllFeatureSliderAsync()
        {
           
            var responseMessage = await _httpClient.GetAsync("FeatureSliders");
            if (responseMessage.IsSuccessStatusCode)
            {
                return await responseMessage.Content.ReadFromJsonAsync<List<ResultFeatureSliderDto>>();
            }
            return new List<ResultFeatureSliderDto>();
        }

        public async Task<UpdateFeatureSliderDto> GetByIdFeatureSliderAsync(string id)
        {
            
            var responseMessage = await _httpClient.GetAsync($"FeatureSliders/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<UpdateFeatureSliderDto>();
            return values;
        }

        public async Task UpdateFeatureSliderAsync(UpdateFeatureSliderDto dto)
        {
                
            await _httpClient.PutAsJsonAsync<UpdateFeatureSliderDto>("FeatureSliders", dto);

        }
    }
}
