using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using MultiShop.DtoLayer.CatalogDtos.ProductImageDtos;
using System.Net.Http;

namespace MultiShop.WebUI.Services.CatalogServices.ProductImagesServices
{
    public class ProductImageService : IProductImageService
    {
        private readonly HttpClient _httpClient;

        public ProductImageService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateProductImageAsync(CreateProductImageDto dto)
        {
            await _httpClient.PostAsJsonAsync<CreateProductImageDto>("ProductImages", dto);

        }

        public async Task DeleteProductImageAsync(string id)
        {
            
            await _httpClient.DeleteAsync($"ProductImages?id={id}");
        }

        public async Task<List<ResultProductImageDto>> GetAllProductImageAsync()
        {
            
            var responseMessage = await _httpClient.GetAsync("ProductImages");
            if (responseMessage.IsSuccessStatusCode)
            {
                return await responseMessage.Content.ReadFromJsonAsync<List<ResultProductImageDto>>();
            }
            return new List<ResultProductImageDto>();
        }

        public async Task<GetByIdProductImageDto> GetByIdProductImageAsync(string id)
        {
            
            var responseMessage = await _httpClient.GetAsync($"ProductImages/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<GetByIdProductImageDto>();
            return values;
        }

        public async Task<GetByIdProductImageDto> GetByProductIdProductImageAsync(string id)
        {
            
            var responseMessage = await _httpClient.GetAsync($"ProductImages/ProductImagesByProductId/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<GetByIdProductImageDto>();
            return values;
        }

        public async Task UpdateProductImageAsync(UpdateProductImageDto dto)
        {
            
            await _httpClient.PutAsJsonAsync<UpdateProductImageDto>("ProductImages", dto);
        }
    }
}
