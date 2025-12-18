using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Dtos.ProductDetailDtos;

namespace MultiShop.Catalog.Services.ProductDetailServices
{
    public interface IProductDetailService
    {
        Task<List<ResultProductDetailDto>> GetAllProductDetailAsync();
        Task CreateProductDetailAsync(CreateProductDetailDto dto);
        Task DeleteProductDetailAsync(string id);
        Task UpdateProductDetailAsync(UpdateProductDetailDto dto);
        Task<GetProductDetailByIdDto> GetByIdProductDetailAsync(string id);
        Task<GetProductDetailByIdDto> GetByProductIdProductDetailAsync(string id);
    }
}
