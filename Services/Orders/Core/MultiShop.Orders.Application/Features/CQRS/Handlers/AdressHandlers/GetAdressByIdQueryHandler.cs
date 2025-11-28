using MultiShop.Orders.Application.Features.CQRS.Queries.AdressQueries;
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
    public class GetAdressByIdQueryHandler
    {
        private readonly IRepository<Adress> _repository;

        public GetAdressByIdQueryHandler(IRepository<Adress> repository)
        {
            _repository = repository;
        }

        public async Task<GetAdressByIdQueryResult> Handle(GetAdressByIdQuery query)
        {
            var result = await _repository.GetByIdAsync(query.Id);
            var resultAdressQuery = new GetAdressByIdQueryResult
            {
                AdressId = result.AdressId,
                City = result.City,
                Detail = result.Detail,
                District = result.District,
                UserId = result.UserId
            };
            return resultAdressQuery;
        }
         
    }
}
