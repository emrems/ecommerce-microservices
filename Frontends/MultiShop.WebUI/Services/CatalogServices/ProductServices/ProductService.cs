using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using System.Net.Http.Json;

namespace MultiShop.WebUI.Services.CatalogServices.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateProductAsync(CreateProductDto dto)
        {
            await _httpClient.PostAsJsonAsync<CreateProductDto>("Products", dto);
        }

        public async Task DeleteProductAsync(string id)
        {
            await _httpClient.DeleteAsync($"Products?id={id}");
        }

        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
            var responseMessage = await _httpClient.GetAsync("Products");

            if (responseMessage.IsSuccessStatusCode)
            {
                return await responseMessage.Content.ReadFromJsonAsync<List<ResultProductDto>>();
            }
            return new List<ResultProductDto>();
        }

        public async Task<UpdateProductDto> GetByIdProductAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync($"Products/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<UpdateProductDto>();
            return values;
        }

        public async Task<List<ResultWithCategoryDto>> getProductByCategoryIdAsync(string id)
        {
            var productWithCategories = await _httpClient.GetAsync($"Products/GetProductByCategoryId/{id}");

            if (productWithCategories.IsSuccessStatusCode)
            {
                return await productWithCategories.Content.ReadFromJsonAsync<List<ResultWithCategoryDto>>();
            }
            return new List<ResultWithCategoryDto>();
        }

        public async Task<List<ResultWithCategoryDto>> getProductsWithCategoryAsync()
        {
            var responseMessage = await _httpClient.GetAsync("Products/ProductListWithCategory");

            if (responseMessage.IsSuccessStatusCode)
            {
                return await responseMessage.Content.ReadFromJsonAsync<List<ResultWithCategoryDto>>();
            }
            return new List<ResultWithCategoryDto>();

        }

        public async Task UpdateProductAsync(UpdateProductDto dto)
        {
            await _httpClient.PutAsJsonAsync<UpdateProductDto>("Products", dto);
        }
    }
}
