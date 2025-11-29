using MediatR;
using MultiShop.Orders.Application.Features.Mediator.Results.OrderingResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Orders.Application.Features.Mediator.Queries.OrderingQueries
{
    // bu classta tek bir entity dönecek aslında  GetOrderingByIdQueryResult tipinde
    public class GetOrderingByIdQuery : IRequest<GetOrderingByIdQueryResult>
    {
         public int Id { get; set; }

        public GetOrderingByIdQuery(int id)
        {
            Id = id;
        }
    }
}
