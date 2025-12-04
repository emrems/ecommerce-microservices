using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Multishop.Cargo.BusinessLayer.Abstract;
using Multishop.Cargo.DtosLayer.Dtos.CargoCustomerDtos;
using Multishop.Cargo.DtosLayer.Dtos.CargoOperationDtos;
using Multishop.Cargo.EntityLayer.Concrate;

namespace Multishop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoOperationsController : ControllerBase
    {
        private readonly ICargoOperationService _service;

        public CargoOperationsController(ICargoOperationService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult CargoOperationList()
        {
            var result = _service.TGetAll();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateCargoOperation(CreateCargoOperationDto dto)
        {
            var createCargoOperation = new CargoOperation
            {
                Description=dto.Description,
                OperationDate=dto.OperationDate,
                Barcode=dto.Barcode
            };
            _service.TInsert(createCargoOperation);
            return Ok("başarıyla eklendi");
        }

        [HttpDelete]
        public IActionResult DeleteCargoOperation(int id)
        {
            _service.TDelete(id);
            return Ok("başarılı silindi");
        }

        [HttpGet("{id}")]
        public IActionResult GetCargoOperationById(int id)
        {
            var result = _service.TGetById(id);
            return Ok(result);
        }

        [HttpPut]
        public IActionResult UpdateCargoOperation(UpdateCargoOperationDto dto)
        {
            var updateCargoOperation = new CargoOperation
            {
                Barcode=dto.Barcode,
                CargoOperationId=dto.CargoOperationId,
                Description=dto.Description,
                OperationDate=dto.OperationDate
            };
            _service.TUpdate(updateCargoOperation);
            return Ok("başarıyla güncellendi");
        }
    }
}
