using MultiShop.DtoLayer.CatalogDtos.SpecialOfferDtos;

namespace MultiShop.WebUI.Services.CatalogServices.SpecialOfferServices
{
    public interface ISpecialOfferService
    {
        Task<List<ResultSpecialOfferDto>> GetAllSpecialOfferAsync();
        Task CreateSpecialOfferAsync(CreateSpecialOfferDto dto);
        Task DeleteSpecialOfferAsync(string id);
        Task UpdateSpecialOfferAsync(UpdateSpecialOfferDto dto);
        Task<UpdateSpecialOfferDto> GetByIdSpecialOfferAsync(string id);
    }
}
