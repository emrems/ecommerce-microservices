using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductDetailDtos;
using MultiShop.Catalog.Dtos.ProductDtos;
using MultiShop.Catalog.Services.ProductDetailServices;

namespace MultiShop.Catalog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailsController : ControllerBase
    {
        private readonly IProductDetailService _productDetailService;

        public ProductDetailsController(IProductDetailService productDetailService)
        {
            _productDetailService = productDetailService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProductDetail()
        {
            var result = await _productDetailService.GetAllProductDetailAsync();
            return Ok(result);
        }
        [HttpGet("GetProductDetailByProductId")]
        public async Task<IActionResult> GetProductDetailByProductId(string id)
        {
            var result = await _productDetailService.GetByProductIdProductDetailAsync(id);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductDetailById(string id)
        {
            var result = await _productDetailService.GetByIdProductDetailAsync(id);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProductDetail(CreateProductDetailDto dto)
        {
            await _productDetailService.CreateProductDetailAsync(dto);
            return Ok("productDetail başarılı bir şekilde eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteProductDetailById(string id)
        {
            await _productDetailService.DeleteProductDetailAsync(id);
            return Ok("ProductDetail silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProductDetail(UpdateProductDetailDto dto)
        {
            await _productDetailService.UpdateProductDetailAsync(dto);
            return Ok("productDetail güncellendi");
        }
    }
}
