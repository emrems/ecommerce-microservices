using MultiShop.DtoLayer.CatalogDtos.ContactDtos;

namespace MultiShop.WebUI.Services.CatalogServices.ContactServices
{
    public interface IContactServices
    {
        Task<List<ResultContactDto>> GetAllContactAsync();
        Task CreateContactAsync(CreateContactDto dto);
        Task DeleteContactAsync(string id);
        Task UpdateContactAsync(UpdateContactDto dto);
        Task<GetByIdContactDto> GetByIdContactAsync(string id);
    }
}
