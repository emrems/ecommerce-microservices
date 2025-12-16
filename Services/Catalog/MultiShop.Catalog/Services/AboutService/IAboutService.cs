using MultiShop.Catalog.Dtos.AbaoutDtos;
using MultiShop.Catalog.Dtos.AbaoutDtos;

namespace MultiShop.Catalog.Services.AboutService
{
    public interface IAboutService
    {
        Task<List<ResultAboutDto>> GetAllAboutAsync();
        Task CreateAboutAsync(CreateAboutDto dto);
        Task DeleteAboutAsync(string id);
        Task UpdateAboutAsync(UpdateAboutDto dto);
        Task<GetByIdAboutDto> GetByIdAboutAsync(string id);
    }
}
