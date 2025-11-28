using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Dtos.ProductDtos;

namespace MultiShop.Catalog.Services.ProductServices
{
    public interface IProductService
    {
        Task<List<ResultProductDto>> GetAllProductAsync();
        Task CreateProductAsync(CreateProductDto dto);
        Task DeleteProductAsync(string id);
        Task UpdateProductAsync(UpdateProductDto dto);
        Task<GetProductByIdDto> GetByIdProductAsync(string id);
    }
}
