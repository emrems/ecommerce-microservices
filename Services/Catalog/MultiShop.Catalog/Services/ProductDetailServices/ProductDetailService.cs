
using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Dtos.ProductDetailDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductDetailServices
{
    
    public class ProductDetailService : IProductDetailService
    {
        private readonly IMongoCollection<ProductDetail> _productDetailCollection;

        private readonly IMapper _mapper;

        public ProductDetailService(IMapper mapper, IDatabaseSettings _settings)
        {

            var client = new MongoClient(_settings.ConnectionString);//bağlantı sağlandı
            var database = client.GetDatabase(_settings.DatabaseName);//db ye gittim
            _productDetailCollection = database.GetCollection<ProductDetail>(_settings.ProductDetailCollectionName);//db collectiona ulaştım
            _mapper = mapper;
        }

        public async Task CreateProductDetailAsync(CreateProductDetailDto dto)
        {
            var value = _mapper.Map<ProductDetail>(dto);
            await _productDetailCollection.InsertOneAsync(value);
        }

        public async Task DeleteProductDetailAsync(string id)
        {
            await _productDetailCollection.DeleteOneAsync(x => x.ProductDetailId == id);
        }

        public async Task<List<ResultProductDetailDto>> GetAllProductDetailAsync()
        {
            var values = await _productDetailCollection.Find(x => true).ToListAsync();
            var productDetailDto = _mapper.Map<List<ResultProductDetailDto>>(values);
            return productDetailDto;
        }

        public async Task<GetProductDetailByIdDto> GetByIdProductDetailAsync(string id)
        {
            var problemDetailDb = await _productDetailCollection.Find(x => x.ProductDetailId == id).FirstOrDefaultAsync();
            var dto = _mapper.Map<GetProductDetailByIdDto>(problemDetailDb);
            return dto;
        }

        public async Task<GetProductDetailByIdDto> GetByProductIdProductDetailAsync(string id)
        {
            var value = await _productDetailCollection.Find(x => x.ProductId == id).FirstOrDefaultAsync();
            var dto = _mapper.Map<GetProductDetailByIdDto>(value);
            return dto;
        }

        public async Task UpdateProductDetailAsync(UpdateProductDetailDto dto)
        {
            var problemDetail = _mapper.Map<ProductDetail>(dto);
            await _productDetailCollection.FindOneAndReplaceAsync(x => x.ProductDetailId == dto.ProductDetailId, problemDetail);
        }
    }
}
