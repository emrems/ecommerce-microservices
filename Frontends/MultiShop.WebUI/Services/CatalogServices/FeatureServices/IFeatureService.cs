using MultiShop.DtoLayer.CatalogDtos.FeatureDtos;

namespace MultiShop.WebUI.Services.CatalogServices.FeatureServices
{
    public interface IFeatureService
    {
         Task<List<ResultFeatureDto>> GetAllFeatureAsync();
        Task CreateFeatureAsync(CreateFeatureDto dto);
        Task DeleteFeatureAsync(string id);
        Task UpdateFeatureAsync(UpdateFeatureDto dto);
        Task<UpdateFeatureDto> GetByIdFeatureAsync(string id);
    }
}
