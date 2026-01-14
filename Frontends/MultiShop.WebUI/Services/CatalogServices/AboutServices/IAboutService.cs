using MultiShop.DtoLayer.CatalogDtos.AboutDtos;

namespace MultiShop.WebUI.Services.CatalogServices.AboutServices
{
    public interface IAboutService
    {
        Task<List<ResultAboutDto>> GetAllAboutAsync();
        Task CreateAboutAsync(CreateAboutDto dto);
        Task DeleteAboutAsync(string id);
        Task UpdateAboutAsync(UpdateAboutDto dto);
        Task<UpdateAboutDto> GetByIdAboutAsync(string id);
    }
}
