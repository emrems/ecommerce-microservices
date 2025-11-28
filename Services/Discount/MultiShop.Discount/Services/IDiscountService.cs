using MultiShop.Discount.Dtos;

namespace MultiShop.Discount.Services
{
    public interface IDiscountService
    {
        Task<List<ResultCouponDto>> getAllCuponAsync();
        Task CreateCuponAsync(CreateCouponDto dto);
        Task UpdateCuponAsync(UpdateCouponDto dto);
        Task DeleteCuponAsync(int id);
        Task<GetByIdCouponDto> getByIdCouponCode(int id);

    }
}
