using MultiShop.Catalog.Dtos.FeatureDtos;

namespace MultiShop.Catalog.Services.FeatureService
{
    public interface IFeatureService
    {
        Task<List<ResultFeatureDto>> GetAllFeatureAsync();
        Task CreateFeatureAsync(CreateFeatureDto dto);
        Task DeleteFeatureAsync(string id);
        Task UpdateFeatureAsync(UpdateFeatureDto dto);
        Task<GetByIdFeatureDto> GetByIdFeatureAsync(string id);
    }
}
