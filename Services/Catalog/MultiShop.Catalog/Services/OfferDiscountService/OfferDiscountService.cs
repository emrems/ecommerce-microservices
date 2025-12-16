using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Dtos.OfferDiscountDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.OfferDiscountService
{
    public class OfferDiscountService : IOfferDiscountService
    {
        private readonly IMongoCollection<OfferDiscount> _offerDiscountCollection;

        private readonly IMapper _mapper;

        public OfferDiscountService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);//bağlantı sağlandı
            var database = client.GetDatabase(_databaseSettings.DatabaseName);//db ye gittim
            _offerDiscountCollection = database.GetCollection<OfferDiscount>(_databaseSettings.OfferDiscountCollectionName);//db collectiona ulaştım
            _mapper = mapper;
        }

        public async Task CreateOfferDiscountAsync(CreateDiscountOfferDto dto)
        {
            var value = _mapper.Map<OfferDiscount>(dto);
            await _offerDiscountCollection.InsertOneAsync(value);
        }

        public async Task DeleteOfferDiscountAsync(string id)
        {
            await _offerDiscountCollection.DeleteOneAsync(x => x.OfferDiscountId == id);
        }

        public async Task<List<ResultOfferDiscountDto>> GetAllOfferDiscountAsync()
        {
            var values = await _offerDiscountCollection.Find(x => true).ToListAsync();
            var offerDiscountReultDto = _mapper.Map<List<ResultOfferDiscountDto>>(values);
            return offerDiscountReultDto;
        }

        public async Task<GetByIdDiscountOfferDto> GetByIdOfferDiscountAsync(string id)
        {
            var categoryDb = await _offerDiscountCollection.Find(x => x.OfferDiscountId == id).FirstOrDefaultAsync();
            var dto = _mapper.Map<GetByIdDiscountOfferDto>(categoryDb);
            return dto;
        }

        public async Task UpdateOfferDiscountAsync(UpdateOfferDiscountOfferDto dto)
        {

            var offerDiscount = _mapper.Map<OfferDiscount>(dto);
            await _offerDiscountCollection.FindOneAndReplaceAsync(x => x.OfferDiscountId == dto.OfferDiscountId, offerDiscount);
        }
    }
}
