using MultiShop.DtoLayer.CatalogDtos.BrandDtos;
using MultiShop.DtoLayer.CatalogDtos.BrandDtos;

namespace MultiShop.WebUI.Services.CatalogServices.BrandServices
{
    public class BrandService : IBrandService
    {
        private readonly HttpClient _httpClient;

        public BrandService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateBrandAsync(CreateBrandDto dto)
        {

            await _httpClient.PostAsJsonAsync<CreateBrandDto>("Brands", dto);

        }

        public async Task DeleteBrandAsync(string id)
        {

            await _httpClient.DeleteAsync($"Brands?id={id}");
        }


        public async Task<List<ResultBrandDto>> GetAllBrandAsync()
        {

            var responseMessage = await _httpClient.GetAsync("Brands");

            if (responseMessage.IsSuccessStatusCode)
            {
                return await responseMessage.Content.ReadFromJsonAsync<List<ResultBrandDto>>();
            }
            return new List<ResultBrandDto>();
        }


        public async Task<UpdateBrandDto> GetByIdBrandAsync(string id)
        {

            var responseMessage = await _httpClient.GetAsync($"Brands/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<UpdateBrandDto>();
            return values;
        }

        public async Task UpdateBrandAsync(UpdateBrandDto dto)
        {

            await _httpClient.PutAsJsonAsync<UpdateBrandDto>("Brands", dto);

        }
    }
}
