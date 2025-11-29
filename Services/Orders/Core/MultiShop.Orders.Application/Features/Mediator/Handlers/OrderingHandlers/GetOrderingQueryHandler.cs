using MediatR;
using MultiShop.Orders.Application.Features.Mediator.Queries.OrderingQueries;
using MultiShop.Orders.Application.Features.Mediator.Results.OrderingResults;
using MultiShop.Orders.Application.Interfaces;
using MultiShop.Orders.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Orders.Application.Features.Mediator.Handlers.OrderingHandlers
{
    // burda aslında diyorsunki GetOrderingQuery tipinde request gelecek GetOrderingQueryResult tipinde list döneceksin
    public class GetOrderingQueryHandler : IRequestHandler<GetOrderingQuery, List<GetOrderingQueryResult>>
    {
        private readonly IRepository<Ordering> _repository;

        public GetOrderingQueryHandler(IRepository<Ordering> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetOrderingQueryResult>> Handle(GetOrderingQuery request, CancellationToken cancellationToken)// bu method mediatr ile geldi
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetOrderingQueryResult
            {
                OrderDate = x.OrderDate,
                TotalPrice = x.TotalPrice,
                UserId = x.UserId,
                OrderingId = x.OrderingId
            }).ToList();
        }
    }
}
