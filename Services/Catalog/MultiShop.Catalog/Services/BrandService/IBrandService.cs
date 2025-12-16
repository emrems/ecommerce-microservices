using MultiShop.Catalog.Dtos.BrandDtos;

namespace MultiShop.Catalog.Services.BrandService
{
    public interface IBrandService
    {
        Task<List<ResultBrandDto>> GetAllBrandAsync();
        Task CreateBrandAsync(CreateBrandDto dto);
        Task DeleteBrandAsync(string id);
        Task UpdateBrandAsync(UpdateBrandDto dto);
        Task<GetByIdBrandDto> GetByIdBrandAsync(string id);
    }
}
