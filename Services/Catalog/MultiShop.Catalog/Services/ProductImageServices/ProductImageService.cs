using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductDtos;
using MultiShop.Catalog.Dtos.ProductImageDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;
using System.Runtime;

namespace MultiShop.Catalog.Services.ProductImageServices
{
    public class ProductImageService : IProductImageService
    {
        private readonly IMapper _mapper;

        private readonly IMongoCollection<ProductImage> _productImageCollection;
        public ProductImageService(IMapper mapper, IDatabaseSettings _settings)
        {
            var client = new MongoClient(_settings.ConnectionString);
            var db = client.GetDatabase(_settings.DatabaseName);
            _productImageCollection = db.GetCollection<ProductImage>(_settings.ProductImageCollectionName);
            _mapper = mapper;
        }

        public async Task CreateProductImageAsync(CreateProductImageDto dto)
        {
            var ProductImage = _mapper.Map<ProductImage>(dto);
            await _productImageCollection.InsertOneAsync(ProductImage);
        }

        public async Task DeleteProductImageAsync(string id)
        {
            await _productImageCollection.DeleteOneAsync(x => x.ProductImageId == id);
        }

        public async Task<List<ResultProductImageDto>> GetAllProductImageAsync()
        {
            var values = await _productImageCollection.Find(x => true).ToListAsync();
            var prodyctReultDto = _mapper.Map<List<ResultProductImageDto>>(values);
            return prodyctReultDto;
        }

        public async Task<GetByIdProductImageDto> GetByIdProductImageAsync(string id)
        {

            var product = await _productImageCollection.Find(x => x.ProductImageId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductImageDto>(product);
        }

        public async Task UpdateProductImageAsync(UpdateProductImageDto dto)
        {

            var value = _mapper.Map<ProductImage>(dto);
            await _productImageCollection.FindOneAndReplaceAsync(x => x.ProductImageId == dto.ProductImageId, value);
        }
    }
}
