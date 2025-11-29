using MultiShop.Orders.Application.Features.CQRS.Queries.AdressQueries;
using MultiShop.Orders.Application.Features.CQRS.Queries.OrderDetailQueries;
using MultiShop.Orders.Application.Features.CQRS.Results.AdressResults;
using MultiShop.Orders.Application.Features.CQRS.Results.OrderDetailResult;
using MultiShop.Orders.Application.Interfaces;
using MultiShop.Orders.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Orders.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class GetOrderDetailByIdQueryHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public GetOrderDetailByIdQueryHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task<GetOrderDetailByIdQueryResult> Handle(GetOrderDetailByIdQuery query)
        {
            var result = await _repository.GetByIdAsync(query.Id);
            var resultAdressQuery = new GetOrderDetailByIdQueryResult
            {
                OrderDetailId = result.OrderDetailId,
                OrderingId = result.OrderingId,
                ProductAmount = result.ProductAmount,
                ProductId = result.ProductId,
                ProductName = result.ProductName,
                ProductPrice=result.ProductPrice,
                ProductTotalPrice=result.ProductTotalPrice
            };
            return resultAdressQuery;
        }
    }
}
