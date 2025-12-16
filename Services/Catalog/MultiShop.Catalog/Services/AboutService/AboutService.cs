using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.AbaoutDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.AboutService
{
    public class AboutService : IAboutService
    {
        private readonly IMongoCollection<About> _aboutCollection;

        private readonly IMapper _mapper;

        public AboutService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);//bağlantı sağlandı
            var database = client.GetDatabase(_databaseSettings.DatabaseName);//db ye gittim
            _aboutCollection = database.GetCollection<About>(_databaseSettings.AboutCollectionName);//db collectiona ulaştım
            _mapper = mapper;
        }

        public async Task CreateAboutAsync(CreateAboutDto dto)
        {
            
            var value = _mapper.Map<About>(dto);
            await _aboutCollection.InsertOneAsync(value);
        }

        public async Task DeleteAboutAsync(string id)
        {
            
            await _aboutCollection.DeleteOneAsync(x => x.AboutID == id);
        }

        public async Task<List<ResultAboutDto>> GetAllAboutAsync()
        {
            
            var values = await _aboutCollection.Find(x => true).ToListAsync();
            var aboutResultDto = _mapper.Map<List<ResultAboutDto>>(values);
            return aboutResultDto;
        }

        public async Task<GetByIdAboutDto> GetByIdAboutAsync(string id)
        {
            
            var aboutDb = await _aboutCollection.Find(x => x.AboutID == id).FirstOrDefaultAsync();
            var dto = _mapper.Map<GetByIdAboutDto>(aboutDb);
            return dto;
        }

        public async Task UpdateAboutAsync(UpdateAboutDto dto)
        {
            
            var about = _mapper.Map<About>(dto);
            await _aboutCollection.FindOneAndReplaceAsync(x => x.AboutID == dto.AboutID, about);
        }
    }
}
