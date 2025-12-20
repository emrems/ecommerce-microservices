using MultiShop.Catalog.Dtos.ContactDtos;

namespace MultiShop.Catalog.Services.ContactServices
{
    public interface IContactService
    {
        Task<List<ResultContactDto>> GetAllContactAsync();
        Task CreateContactAsync(CreateContactDto dto);
        Task DeleteContactAsync(string id);
        Task UpdateContactAsync(UpdateContactDto dto);
        Task<GetByIdContactDto> GetByIdContactAsync(string id);
    }
}
