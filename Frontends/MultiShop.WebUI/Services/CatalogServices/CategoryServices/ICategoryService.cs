using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;

namespace MultiShop.WebUI.Services.CatalogServices.CategoryServices
{
    public interface ICategoryService
    {
        Task<List<ResultCategoryDto>> GetAllCategoryAsync();
        Task CreateCategoryAsync(CreateCategoryDto dto);
        Task DeleteCategoryAsync(string id);
        Task UpdateCategoryAsync(UpdateCategoryDto dto);
        Task<UpdateCategoryDto> GetByIdCategoryAsync(string id);
    }
}
