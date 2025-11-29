using MediatR;
using MultiShop.Orders.Application.Features.Mediator.Results.OrderingResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Orders.Application.Features.Mediator.Queries.OrderingQueries
{
    // buranın amacı cqrs de olduğu gibi contorllerda her seferinde field oluştrup ctor injeksiyonu yapmadan merkezi bir yerden yönetmek
    // bu classta list dönecek
    public class GetOrderingQuery : IRequest<List<GetOrderingQueryResult>>
    {

    }
}
