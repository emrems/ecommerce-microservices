using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Dtos.ProductDetailDtos;
using MultiShop.Catalog.Dtos.ProductImageDtos;

namespace MultiShop.Catalog.Services.ProductImageServices
{
    public interface IProductImageService
    {
        Task<List<ResultProductImageDto>> GetAllProductImageAsync();
        Task CreateProductImageAsync(CreateProductImageDto dto);
        Task DeleteProductImageAsync(string id);
        Task UpdateProductImageAsync(UpdateProductImageDto dto);
        Task<GetByIdProductImageDto> GetByIdProductImageAsync(string id);
    }
}
