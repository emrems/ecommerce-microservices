using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Orders.Application.Features.CQRS.Commands.AdressCommands;
using MultiShop.Orders.Application.Features.CQRS.Handlers.AdressHandlers;
using MultiShop.Orders.Application.Features.CQRS.Queries.AdressQueries;

namespace MultiShop.Orders.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AdressesController : ControllerBase
    {
        private readonly GetAdressQueryHandler _getAdressQueryHandler;
        private readonly GetAdressByIdQueryHandler _getAdressByIdQueryHandler;
        private readonly CreateAdressCommandHandler _createAdressCommandHandler;
        private readonly UpdateAdressCommandHandler _updateAdressCommandHandler;
        private readonly RemoveAdressCommandHandler _removeAdressCommandHandler;
        public AdressesController(GetAdressQueryHandler getAdressQueryHandler, GetAdressByIdQueryHandler getAdressByIdQueryHandler, CreateAdressCommandHandler createAdressCommandHandler, UpdateAdressCommandHandler updateAdressCommandHandler, RemoveAdressCommandHandler removeAdressCommandHandler)
        {
            _getAdressQueryHandler = getAdressQueryHandler;
            _getAdressByIdQueryHandler = getAdressByIdQueryHandler;
            _createAdressCommandHandler = createAdressCommandHandler;
            _updateAdressCommandHandler = updateAdressCommandHandler;
            _removeAdressCommandHandler = removeAdressCommandHandler;
        }
        [HttpGet]
        public async Task<IActionResult> getAllAdress()
        {
            var result = await _getAdressQueryHandler.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> getAdressById(int id)
        {
            var result = await _getAdressByIdQueryHandler.Handle(new GetAdressByIdQuery(id));
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAdress(CreateAdressCommand command)
        {
             await _createAdressCommandHandler.Handle(command);
            return Ok("adress eklendi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAdress(UpdateAdressCommand command)
        {
            await _updateAdressCommandHandler.Handle(command);
            return Ok("adress güncellendi");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveAdress(int id)
        {
            await _removeAdressCommandHandler.Handle(new RemoveAdressCommand(id));
    
            return Ok("adress silindi");
        }
    }
}
