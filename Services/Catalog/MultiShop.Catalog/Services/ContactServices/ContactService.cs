using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ContactDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ContactServices
{
    public class ContactService : IContactService
    {
        private readonly IMongoCollection<Contact> _contactCollection;

        private readonly IMapper _mapper;

        public ContactService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {

            var client = new MongoClient(_databaseSettings.ConnectionString);//bağlantı sağlandı
            var database = client.GetDatabase(_databaseSettings.DatabaseName);//db ye gittim
            _contactCollection = database.GetCollection<Contact>(_databaseSettings.ContactCollectionName);//db collectiona ulaştım
            _mapper = mapper;
        }

        public async Task CreateContactAsync(CreateContactDto dto)
        {
            
            var contact = _mapper.Map<Contact>(dto);
            await _contactCollection.InsertOneAsync(contact);
        }

        public async Task DeleteContactAsync(string id)
        {
           
            await _contactCollection.DeleteOneAsync(x => x.ContactID == id);
        }

        public async Task<List<ResultContactDto>> GetAllContactAsync()
        {
            
            var contacts = await _contactCollection.Find(x => true).ToListAsync();
            var resultContactDto = _mapper.Map<List<ResultContactDto>>(contacts);
            return resultContactDto;
        }

        public async Task<GetByIdContactDto> GetByIdContactAsync(string id)
        {
           
            var contactDb = await _contactCollection.Find(x => x.ContactID == id).FirstOrDefaultAsync();
            var dto = _mapper.Map<GetByIdContactDto>(contactDb);
            return dto;
        }

        public async Task UpdateContactAsync(UpdateContactDto dto)
        {
            
            var contact = _mapper.Map<Contact>(dto);
            await _contactCollection.FindOneAndReplaceAsync(x => x.ContactID == dto.ContactID, contact);
        }
    }
}
