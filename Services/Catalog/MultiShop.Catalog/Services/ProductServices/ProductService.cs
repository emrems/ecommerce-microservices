using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Dtos.ProductDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IMongoCollection<Category> _categoryCollection;
        public ProductService(IMapper mapper, IDatabaseSettings _settings)
        {
            var client = new MongoClient(_settings.ConnectionString);
            var db = client.GetDatabase(_settings.DatabaseName);
            _productCollection = db.GetCollection<Product>(_settings.ProductCollectionName);

            _mapper = mapper;
            _categoryCollection = db.GetCollection<Category>(_settings.CategoryCollectionName);
        }

        public async Task CreateProductAsync(CreateProductDto dto)
        {
            var product = _mapper.Map<Product>(dto);
            await _productCollection.InsertOneAsync(product);
        }

        public async Task DeleteProductAsync(string id)
        {
            await _productCollection.DeleteOneAsync(x => x.ProductId == id);
        }

        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
            var values = await _productCollection.Find(x => true).ToListAsync();
            var prodyctReultDto = _mapper.Map<List<ResultProductDto>>(values);
            return prodyctReultDto;
        }

        public async Task<GetProductByIdDto> GetByIdProductAsync(string id)
        {
            var product = await _productCollection.Find(x => x.ProductId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetProductByIdDto>(product);
        }

        public async Task<List<ResultProductsWithCategoryDto>> getProductByCategoryIdAsync(string id)
        {
            
            var values = await _productCollection.Find(x => x.CategoryID == id).ToListAsync();
            foreach (var product in values)
            {
                product.Category = await _categoryCollection.Find<Category>(x => x.CategoryID == product.CategoryID).FirstAsync();
            }
            return _mapper.Map<List<ResultProductsWithCategoryDto>>(values);
        }

        public async Task<List<ResultProductsWithCategoryDto>> getProductsWithCategoryAsync()
        {
            var values = await _productCollection.Find(x => true).ToListAsync();
            foreach (var product in values)
            {
                product.Category = await _categoryCollection.Find<Category>(x => x.CategoryID == product.CategoryID).FirstAsync();
                
            }
            return _mapper.Map<List<ResultProductsWithCategoryDto>>(values);
        }

        public async Task UpdateProductAsync(UpdateProductDto dto)
        {
            var value = _mapper.Map<Product>(dto);
            await _productCollection.FindOneAndReplaceAsync(x => x.ProductId == dto.ProductId, value);
        }
    }
}
