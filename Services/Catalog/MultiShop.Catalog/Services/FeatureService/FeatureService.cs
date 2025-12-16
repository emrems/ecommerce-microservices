using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Dtos.FeatureDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.FeatureService
{
    public class FeatureService : IFeatureService
    {
        private readonly IMongoCollection<Feature> _featureCollection;

        private readonly IMapper _mapper;

        public FeatureService(IDatabaseSettings _databaseSettings, IMapper mapper)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);//bağlantı sağlandı
            var database = client.GetDatabase(_databaseSettings.DatabaseName);//db ye gittim
            _featureCollection = database.GetCollection<Feature>(_databaseSettings.FeatureCollectionName);//db collectiona ulaştım
            _mapper = mapper;
        }
        public async Task CreateFeatureAsync(CreateFeatureDto dto)
        {
            var value = _mapper.Map<Feature>(dto);
            await _featureCollection.InsertOneAsync(value);
        }

        public async Task DeleteFeatureAsync(string id)
        {
            await _featureCollection.DeleteOneAsync(x => x.FeatureID == id);
        }

        public async Task<List<ResultFeatureDto>> GetAllFeatureAsync()
        {

            var values = await _featureCollection.Find(x => true).ToListAsync();
            var featureReultDto = _mapper.Map<List<ResultFeatureDto>>(values);
            return featureReultDto;
        }

        public async Task<GetByIdFeatureDto> GetByIdFeatureAsync(string id)
        {
            var featureDb = await _featureCollection.Find(x => x.FeatureID == id).FirstOrDefaultAsync();
            var dto = _mapper.Map<GetByIdFeatureDto>(featureDb);
            return dto;
        }

        public async Task UpdateFeatureAsync(UpdateFeatureDto dto)
        {

            var feature = _mapper.Map<Feature>(dto);
            await _featureCollection.FindOneAndReplaceAsync(x => x.FeatureID == dto.FeatureID, feature);
        }
    }
}
