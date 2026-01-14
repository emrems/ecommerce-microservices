using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;

namespace MultiShop.WebUI.Services.CatalogServices.CategoryServices
{
    // bu classta istek atılan categories kısmının base kısmı program.cs de httpclient eklenirken ayarlanıyor
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _httpClient;

        public CategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateCategoryAsync(CreateCategoryDto dto)
        {
            
             await _httpClient.PostAsJsonAsync<CreateCategoryDto>("categories", dto);
            
        }

        public async Task DeleteCategoryAsync(string id)
        { 
            
            await _httpClient.DeleteAsync($"Categories?id={id}");
        }

        
        public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
        {
            
            var responseMessage = await _httpClient.GetAsync("categories");

            if (responseMessage.IsSuccessStatusCode)
            {
                return await responseMessage.Content.ReadFromJsonAsync<List<ResultCategoryDto>>();
            }
            return new List<ResultCategoryDto>();
        }
       

        public async Task<UpdateCategoryDto> GetByIdCategoryAsync(string id)
        {
            
            var responseMessage = await _httpClient.GetAsync($"categories/"+id);
            var values = await responseMessage.Content.ReadFromJsonAsync<UpdateCategoryDto>();
            return values;
        }

        public async Task UpdateCategoryAsync(UpdateCategoryDto dto)
        {
            
            await _httpClient.PutAsJsonAsync<UpdateCategoryDto>("categories", dto);

        }
    }
}
