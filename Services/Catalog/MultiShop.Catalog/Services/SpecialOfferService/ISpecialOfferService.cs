using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Dtos.SpecialOfferDtos;

namespace MultiShop.Catalog.Services.SpecialOfferService
{
    public interface ISpecialOfferService
    {
        Task<List<ResultSpecialOfferDto>> GetAllSpecialOfferAsync();
        Task CreateSpecialOfferAsync(CreateSpecialOfferDto dto);
        Task DeleteSpecialOfferAsync(string id);
        Task UpdateSpecialOfferAsync(UpdateSpecialOfferDto dto);
        Task<GetByIdSpecialOfferDto> GetByIdSpecialOfferAsync(string id);
    }
}
