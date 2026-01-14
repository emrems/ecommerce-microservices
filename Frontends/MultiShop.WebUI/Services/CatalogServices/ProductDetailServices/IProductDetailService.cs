using MultiShop.DtoLayer.CatalogDtos.ProductDetailDtos;

namespace MultiShop.WebUI.Services.CatalogServices.ProductDetailServices
{
    public interface IProductDetailService
    {
        Task<List<ResultProductDetailDto>> GetAllProductDetailAsync();
        Task CreateProductDetailAsync(CreateProductDetailDto dto);
        Task DeleteProductDetailAsync(string id);
        Task UpdateProductDetailAsync(UpdateProductDetailDto dto);
        Task<UpdateProductDetailDto> GetByIdProductDetailAsync(string id);
        Task<UpdateProductDetailDto> GetByProductIdProductDetailAsync(string id);
    }
}
