using MultiShop.Orders.Application.Features.CQRS.Commands.AdressCommands;
using MultiShop.Orders.Application.Features.CQRS.Commands.OrderDetailCommands;
using MultiShop.Orders.Application.Interfaces;
using MultiShop.Orders.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Orders.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class UpdateOrderDetailQueryHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public UpdateOrderDetailQueryHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateOrderDetailCommand command)
        {
            var value = await _repository.GetByIdAsync(command.OrderDetailId);
            value.ProductName = command.ProductName;
            value.ProductPrice = command.ProductPrice;
            value.ProductTotalPrice = command.ProductTotalPrice;
            value.OrderingId = command.OrderingId;
            value.ProductAmount = command.ProductAmount;
            value.ProductId = command.ProductId;
            await _repository.UpdateAsync(value);
        }
    }
}
