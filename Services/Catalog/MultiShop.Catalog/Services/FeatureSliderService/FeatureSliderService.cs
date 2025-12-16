using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Dtos.FeatureSliderDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.FeatureSliderService
{
    public class FeatureSliderService : IFeatureSliderService
    {
        private readonly IMongoCollection<FeatureSlider> _featureSliderCollection;

        private readonly IMapper _mapper;

        public FeatureSliderService(IDatabaseSettings _databaseSettings, IMapper mapper)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);//bağlantı sağlandı
            var database = client.GetDatabase(_databaseSettings.DatabaseName);//db ye gittim
            _featureSliderCollection = database.GetCollection<FeatureSlider>(_databaseSettings.FeatureSliderCollectionName);//db collectiona ulaştım
            _mapper = mapper;
        }
        public async Task CreateFeatureSliderAsync(CreateFeatureSliderDto dto)
        {
            var value = _mapper.Map<FeatureSlider>(dto);
            await _featureSliderCollection.InsertOneAsync(value);
        }

        public async Task DeleteFeatureSliderAsync(string id)
        {
            await _featureSliderCollection.DeleteOneAsync(x => x.FeatureSliderID == id);
        }

        public Task FeatureSliderChangeStatusToFalse(string id)
        {
            throw new NotImplementedException();
        }

        public Task FeatureSliderChangeStatusToTrue(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ResultFeatureSliderDto>> GetAllFeatureSliderAsync()
        {
            var values = await _featureSliderCollection.Find(x => true).ToListAsync();
            var ResultFeatureSliderDto = _mapper.Map<List<ResultFeatureSliderDto>>(values);
            return ResultFeatureSliderDto;
        }

        public async Task<GetByIdFeatureSliderDto> GetByIdFeatureSliderAsync(string id)
        {
            var featureSliderDb = await _featureSliderCollection.Find(x => x.FeatureSliderID == id).FirstOrDefaultAsync();
            var dto = _mapper.Map<GetByIdFeatureSliderDto>(featureSliderDb);
            return dto;
        }

        public async Task UpdateFeatureSliderAsync(UpdateFeatureSliderDto dto)
        {

            var slider = _mapper.Map<FeatureSlider>(dto);
            await _featureSliderCollection.FindOneAndReplaceAsync(x => x.FeatureSliderID == dto.FeatureSliderID, slider);
        }
    }
}
