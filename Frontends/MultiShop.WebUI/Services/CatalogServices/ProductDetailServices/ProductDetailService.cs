using MultiShop.DtoLayer.CatalogDtos.ProductDetailDtos;

namespace MultiShop.WebUI.Services.CatalogServices.ProductDetailServices
{
    public class ProductDetailService : IProductDetailService
    {
        private readonly HttpClient _httpClient;

        public ProductDetailService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateProductDetailAsync(CreateProductDetailDto dto)
        {
            
           await _httpClient.PostAsJsonAsync("Productdetails", dto);
            
        }

        public async Task DeleteProductDetailAsync(string id)
        {
           
            await _httpClient.DeleteAsync($"Productdetails?id={id}");

        }

        public async Task<List<ResultProductDetailDto>> GetAllProductDetailAsync()
        {
           
            var responseMessage = await _httpClient.GetAsync("Productdetails");
            if (responseMessage.IsSuccessStatusCode)
            {
                return await responseMessage.Content.ReadFromJsonAsync<List<ResultProductDetailDto>>();
            }
            return new List<ResultProductDetailDto>();
        }

        public async Task<UpdateProductDetailDto> GetByIdProductDetailAsync(string id)
        {
            
            var responseMessage = await _httpClient.GetAsync($"Productdetails/"+id);
            var values = await responseMessage.Content.ReadFromJsonAsync<UpdateProductDetailDto>();
            return values;
        }

        public async Task<UpdateProductDetailDto> GetByProductIdProductDetailAsync(string id)
        {
            
            var responseMessage = await _httpClient.GetAsync($"Productdetails/GetProductDetailByProductId/"+id);
            var values = await responseMessage.Content.ReadFromJsonAsync<UpdateProductDetailDto>();
            return values;
        }

        public async Task UpdateProductDetailAsync(UpdateProductDetailDto dto)
        {
            
            await _httpClient.PutAsJsonAsync("Productdetails", dto);
        }
    }
}
