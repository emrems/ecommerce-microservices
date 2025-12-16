using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Dtos.OfferDiscountDtos;

namespace MultiShop.Catalog.Services.OfferDiscountService
{
    public interface IOfferDiscountService
    {
        Task<List<ResultOfferDiscountDto>> GetAllOfferDiscountAsync();
        Task CreateOfferDiscountAsync(CreateDiscountOfferDto dto);
        Task DeleteOfferDiscountAsync(string id);
        Task UpdateOfferDiscountAsync(UpdateOfferDiscountOfferDto dto);
        Task<GetByIdDiscountOfferDto> GetByIdOfferDiscountAsync(string id);
    }
}
