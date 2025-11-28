using MultiShop.Orders.Application.Features.CQRS.Commands.AdressCommands;
using MultiShop.Orders.Application.Interfaces;
using MultiShop.Orders.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Orders.Application.Features.CQRS.Handlers.AdressHandlers
{
    public class UpdateAdressCommandHandler
    {
        private readonly IRepository<Adress> _repository;

        public UpdateAdressCommandHandler(IRepository<Adress> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateAdressCommand command)
        {
            var value = await _repository.GetByIdAsync(command.AdressId);
            value.Detail = command.Detail;
            value.City = command.City;
            value.District = command.District;
            value.UserId = command.UserId;
            await _repository.UpdateAsync(value);
        }
    }
}
