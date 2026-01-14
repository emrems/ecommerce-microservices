using MultiShop.DtoLayer.CatalogDtos.OfferDiscountDtos;

namespace MultiShop.WebUI.Services.CatalogServices.OfferDiscountServices
{
    public interface IOfferDiscountService
    {
        Task<List<ResultOfferDiscountDto>> GetAllOfferDiscountAsync();
        Task CreateOfferDiscountAsync(CreateOfferDiscountDto dto);
        Task DeleteOfferDiscountAsync(string id);
        Task UpdateOfferDiscountAsync(UpdateOfferDiscountDto dto);
        Task<UpdateOfferDiscountDto> GetByIdOfferDiscountAsync(string id);
    }
}
