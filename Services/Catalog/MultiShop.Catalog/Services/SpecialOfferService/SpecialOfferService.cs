using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Dtos.SpecialOfferDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.SpecialOfferService
{
    public class SpecialOfferService : ISpecialOfferService
    {
        private readonly IMongoCollection<SpecialOffer> _specialOfferCollection;

        private readonly IMapper _mapper;

        public SpecialOfferService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);//bağlantı sağlandı
            var database = client.GetDatabase(_databaseSettings.DatabaseName);//db ye gittim
            _specialOfferCollection = database.GetCollection<SpecialOffer>(_databaseSettings.SpecialOfferCollectionName);//db collectiona ulaştım
            _mapper = mapper;
        }

        public async Task CreateSpecialOfferAsync(CreateSpecialOfferDto dto)
        {
            var value = _mapper.Map<SpecialOffer>(dto);
            await _specialOfferCollection.InsertOneAsync(value);
        }

        public async Task DeleteSpecialOfferAsync(string id)
        {
            await _specialOfferCollection.DeleteOneAsync(x => x.SpecialOfferId == id);
        }

        public async Task<List<ResultSpecialOfferDto>> GetAllSpecialOfferAsync()
        {
            var values = await _specialOfferCollection.Find(x => true).ToListAsync();
            var ResultSpecialDto = _mapper.Map<List<ResultSpecialOfferDto>>(values);
            return ResultSpecialDto;
        }

        public async Task<GetByIdSpecialOfferDto> GetByIdSpecialOfferAsync(string id)
        {
            var specialOfferDb = await _specialOfferCollection.Find(x => x.SpecialOfferId == id).FirstOrDefaultAsync();
            var dto = _mapper.Map<GetByIdSpecialOfferDto>(specialOfferDb);
            return dto;
        }

        public async Task UpdateSpecialOfferAsync(UpdateSpecialOfferDto dto)
        {

            var specialOffer = _mapper.Map<SpecialOffer>(dto);
            await _specialOfferCollection.FindOneAndReplaceAsync(x => x.SpecialOfferId == dto.SpecialOfferId, specialOffer);
        }
    }
}
