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
    public class RemoveOrderDetailQueryHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public RemoveOrderDetailQueryHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveOrderDetailCommand command)
        {
            var values = await _repository.GetByIdAsync(command.Id);
            await _repository.DeleteAsync(values);
        }
    }
}
