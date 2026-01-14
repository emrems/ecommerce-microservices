using MultiShop.DtoLayer.CatalogDtos.ProductDtos;

namespace MultiShop.WebUI.Services.CatalogServices.ProductServices
{
    public interface IProductService
    {
        Task<List<ResultProductDto>> GetAllProductAsync();
        Task CreateProductAsync(CreateProductDto dto);
        Task DeleteProductAsync(string id);
        Task UpdateProductAsync(UpdateProductDto dto);
        Task<UpdateProductDto> GetByIdProductAsync(string id);
        Task<List<ResultWithCategoryDto>> getProductsWithCategoryAsync();
        Task<List<ResultWithCategoryDto>> getProductByCategoryIdAsync(string id);
    }
}
