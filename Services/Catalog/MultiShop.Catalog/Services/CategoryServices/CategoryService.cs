using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly IMongoCollection<Category> _categoryCollection;

        private readonly IMapper _mapper;

        public CategoryService(IDatabaseSettings _databaseSettings, IMapper mapper)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);//bağlantı sağlandı
            var database = client.GetDatabase(_databaseSettings.DatabaseName);//db ye gittim
            _categoryCollection = database.GetCollection<Category>(_databaseSettings.DatabaseName);//db collectiona ulaştım
            _mapper = mapper;
        }

        public async Task CreateCategoryAsync(CreateCategoryDto dto)
        {
            var value = _mapper.Map<Category>(dto);
            await _categoryCollection.InsertOneAsync(value);
        }

        public async Task DeleteCategoryAsync(string id)
        {
            await _categoryCollection.DeleteOneAsync(x => x.CategoryID == id);
        }

        public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
        {
            var values= await _categoryCollection.Find(x => true).ToListAsync();
            var categoryReultDto = _mapper.Map<List<ResultCategoryDto>>(values);
            return categoryReultDto;
        }

        public async Task<GetByIdCategoryDto> GetByIdCategoryAsync(string id)
        {
            var categoryDb = await _categoryCollection.Find(x => x.CategoryID == id).FirstOrDefaultAsync();
            var dto = _mapper.Map<GetByIdCategoryDto>(categoryDb);
            return dto;
        }

        public async Task UpdateCategoryAsync(UpdateCategoryDto dto)
        {
            var category =  _mapper.Map<Category>(dto);
            await _categoryCollection.FindOneAndReplaceAsync(x=>x.CategoryID == dto.CategoryID,category);
        }
    }
}
