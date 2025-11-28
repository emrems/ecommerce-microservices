using MultiShop.Orders.Application.Features.CQRS.Results.AdressResults;
using MultiShop.Orders.Application.Interfaces;
using MultiShop.Orders.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Orders.Application.Features.CQRS.Handlers.AdressHandlers
{
    public class GetAdressQueryHandler
    {
        private readonly IRepository<Adress> _repository;

        public GetAdressQueryHandler(IRepository<Adress> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetAdressQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetAdressQueryResult
            {
                AdressId = x.AdressId,
                Detail = x.Detail,
                District = x.District,
                City = x.City,
                UserId = x.UserId
            }).ToList();
        }

    }
}
