using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Orders.Application.Features.Mediator.Commands.OrderingCommands;
using MultiShop.Orders.Application.Features.Mediator.Queries.OrderingQueries;

namespace MultiShop.Orders.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderingsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderingsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> getAllOrdering()
        {
            // send methodu içinde IRequestten kalıtım aldığımız sınıfı vermemiz lazım
            var value= await _mediator.Send(new GetOrderingQuery());
            return Ok(value);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> getOrderingById(int id)
        {
          
            var value = await _mediator.Send(new GetOrderingByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrdering(CreateOrderingCommand command)
        {
            
           await _mediator.Send(new CreateOrderingCommand());
            return Ok("sipariş eklendi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateOrdering()
        {
            
            await _mediator.Send(new UpdateOrderingCommand());
            return Ok("sipariş güncellendi");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteOrdering(int id)
        {
            await _mediator.Send(new RemoveOrderingCommand(id));
            return Ok("sipariş silindi");
        }

    }
}
