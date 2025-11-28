using MultiShop.Catalog.Dtos.CategoryDtos;

namespace MultiShop.Catalog.Services.CategoryServices
{
    public interface ICategoryService
    {
        Task<List<ResultCategoryDto>> GetAllCategoryAsync();
        Task CreateCategoryAsync(CreateCategoryDto dto);
        Task DeleteCategoryAsync(string id);
        Task UpdateCategoryAsync(UpdateCategoryDto dto);
        Task<GetByIdCategoryDto> GetByIdCategoryAsync(string id);

    }
}
