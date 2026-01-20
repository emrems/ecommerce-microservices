using MultiShop.DtoLayer.CatalogDtos.ContactDtos;

namespace MultiShop.WebUI.Services.CatalogServices.ContactServices
{
    public class ContactService : IContactServices
    {
        private readonly HttpClient _httpClient;

        public ContactService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateContactAsync(CreateContactDto dto)
        {
            await _httpClient.PostAsJsonAsync("Contacts", dto);
        }

        public async Task DeleteContactAsync(string id)
        {
           await _httpClient.DeleteAsync($"Contacts/{id}");
        }

        public async Task<List<ResultContactDto>> GetAllContactAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<List<ResultContactDto>>("Contacts");
            return response;
        }

        public async Task<GetByIdContactDto> GetByIdContactAsync(string id)
        {
           
            var response = await _httpClient.GetFromJsonAsync<GetByIdContactDto>($"Contacts/{id}");
            return response;
        }

        public async Task UpdateContactAsync(UpdateContactDto dto)
        {
           
            await _httpClient.PutAsJsonAsync("Contacts", dto);
        }
    }
}
