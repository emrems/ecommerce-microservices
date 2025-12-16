using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.BrandDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.BrandService
{
    public class BrandService : IBrandService
    {
        private readonly IMongoCollection<Brand> _brandCollection;

        private readonly IMapper _mapper;

        public BrandService(IMapper mapper,IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);//bağlantı sağlandı
            var database = client.GetDatabase(_databaseSettings.DatabaseName);//db ye gittim
            _brandCollection = database.GetCollection<Brand>(_databaseSettings.BrandCollectionName);//db collectiona ulaştım
            _mapper = mapper;
        }

        public async Task CreateBrandAsync(CreateBrandDto dto)
        {
            
            var brand = _mapper.Map<Brand>(dto);
            await _brandCollection.InsertOneAsync(brand);
        }

        public async Task DeleteBrandAsync(string id)
        {
            
            await _brandCollection.DeleteOneAsync(x => x.BrandID == id);
        }

        public async Task<List<ResultBrandDto>> GetAllBrandAsync()
        {
            
            var brands = await _brandCollection.Find(x => true).ToListAsync();
            var brandResultDto = _mapper.Map<List<ResultBrandDto>>(brands);
            return brandResultDto;
        }

        public async Task<GetByIdBrandDto> GetByIdBrandAsync(string id)
        {
           
            var brandDb = await _brandCollection.Find(x => x.BrandID == id).FirstOrDefaultAsync();
            var dto = _mapper.Map<GetByIdBrandDto>(brandDb);
            return dto;
        }

        public async Task UpdateBrandAsync(UpdateBrandDto dto)
        {
            
            var brand = _mapper.Map<Brand>(dto);
            await _brandCollection.FindOneAndReplaceAsync(x => x.BrandID == dto.BrandID, brand);
        }
    }
}
