using MultiShop.DtoLayer.CatalogDtos.FeatureDtos;
using MultiShop.DtoLayer.CatalogDtos.FeatureDtos;

namespace MultiShop.WebUI.Services.CatalogServices.FeatureServices
{
    public class FeatureService : IFeatureService
    {
        private readonly HttpClient _httpClient;

        public FeatureService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateFeatureAsync(CreateFeatureDto dto)
        {

            await _httpClient.PostAsJsonAsync<CreateFeatureDto>("Features", dto);

        }

        public async Task DeleteFeatureAsync(string id)
        {

            await _httpClient.DeleteAsync($"Features?id={id}");
        }


        public async Task<List<ResultFeatureDto>> GetAllFeatureAsync()
        {

            var responseMessage = await _httpClient.GetAsync("Features");

            if (responseMessage.IsSuccessStatusCode)
            {
                return await responseMessage.Content.ReadFromJsonAsync<List<ResultFeatureDto>>();
            }
            return new List<ResultFeatureDto>();
        }


        public async Task<UpdateFeatureDto> GetByIdFeatureAsync(string id)
        {

            var responseMessage = await _httpClient.GetAsync($"Features/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<UpdateFeatureDto>();
            return values;
        }

        public async Task UpdateFeatureAsync(UpdateFeatureDto dto)
        {

            await _httpClient.PutAsJsonAsync<UpdateFeatureDto>("Features", dto);

        }
    }
}
