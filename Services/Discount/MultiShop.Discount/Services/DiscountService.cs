using Dapper;
using MultiShop.Discount.Context;
using MultiShop.Discount.Dtos;

namespace MultiShop.Discount.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly DapperContext _context;

        public DiscountService(DapperContext context)
        {
            _context = context;
        }

        public async Task CreateCuponAsync(CreateCouponDto dto)
        {
            string query = "insert into Coupons(Code,Rate,IsActive,ValidDate) values (@code,@rate,@isActive,@validDate)";
            var parameters = new DynamicParameters();
            parameters.Add("@code", dto.Code);
            parameters.Add("@rate", dto.Rate);
            parameters.Add("@isActive", dto.IsActive);
            parameters.Add("@validDate", dto.ValidDate);
            using (var connection = _context.CreateConnection()) 
            {
                await connection.ExecuteAsync(query, parameters);
            }

        }

        public async Task DeleteCuponAsync(int id)
        {
            string query = "Delete From Coupons where CouponId=@couponId";
            var parameters = new DynamicParameters();
            parameters.Add("couponId", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultCouponDto>> getAllCuponAsync()
        {
            string query = "Select * From Coupons";
            using (var connection = _context.CreateConnection())
            {
                var values= await connection.QueryAsync<ResultCouponDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIdCouponDto> getByIdCouponCode(int id)
        {
            string query = "SELECT * FROM Coupons WHERE CouponId = @couponId";

            var parameters = new DynamicParameters();
            parameters.Add("@couponId", id);

            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryFirstOrDefaultAsync<GetByIdCouponDto>(query, parameters);
            }
        }


        public async Task UpdateCuponAsync(UpdateCouponDto dto)
        {
            string query = "Update Coupons Set Code=@code, Rate=@rate, IsActive=@isActive, ValidDate=@validDate where CouponId=@couponId";
            var parameters = new DynamicParameters();
            parameters.Add("@code", dto.Code);
            parameters.Add("@rate", dto.Rate);
            parameters.Add("@isActive", dto.IsActive);
            parameters.Add("@validDate", dto.ValidDate);
            parameters.Add("@couponId", dto.CouponId);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
