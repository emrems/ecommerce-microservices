using MultiShop.DtoLayer.CatalogDtos.BrandDtos;

namespace MultiShop.WebUI.Services.CatalogServices.BrandServices
{
    public interface IBrandService
    {
        Task<List<ResultBrandDto>> GetAllBrandAsync();
        Task CreateBrandAsync(CreateBrandDto dto);
        Task DeleteBrandAsync(string id);
        Task UpdateBrandAsync(UpdateBrandDto dto);
        Task<UpdateBrandDto> GetByIdBrandAsync(string id);
    }
}
