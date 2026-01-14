using MultiShop.DtoLayer.CatalogDtos.AboutDtos;
using MultiShop.DtoLayer.CatalogDtos.AboutDtos;

namespace MultiShop.WebUI.Services.CatalogServices.AboutServices
{
    public class AboutService : IAboutService
    {
        private readonly HttpClient _httpClient;

        public AboutService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateAboutAsync(CreateAboutDto dto)
        {

            await _httpClient.PostAsJsonAsync<CreateAboutDto>("Abouts", dto);

        }

        public async Task DeleteAboutAsync(string id)
        {

            await _httpClient.DeleteAsync($"Abouts?id={id}");
        }


        public async Task<List<ResultAboutDto>> GetAllAboutAsync()
        {

            var responseMessage = await _httpClient.GetAsync("Abouts");

            if (responseMessage.IsSuccessStatusCode)
            {
                return await responseMessage.Content.ReadFromJsonAsync<List<ResultAboutDto>>();
            }
            return new List<ResultAboutDto>();
        }


        public async Task<UpdateAboutDto> GetByIdAboutAsync(string id)
        {

            var responseMessage = await _httpClient.GetAsync($"Abouts/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<UpdateAboutDto>();
            return values;
        }

        public async Task UpdateAboutAsync(UpdateAboutDto dto)
        {

            await _httpClient.PutAsJsonAsync<UpdateAboutDto>("Abouts", dto);

        }
    }
}
