using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Multishop.Cargo.BusinessLayer.Abstract;
using Multishop.Cargo.DtosLayer.Dtos.CargoCompanyDtos;
using Multishop.Cargo.DtosLayer.Dtos.CargoCustomerDtos;
using Multishop.Cargo.EntityLayer.Concrate;

namespace Multishop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCustomersController : ControllerBase
    {
        private readonly ICargoCustomerService _service;

        public CargoCustomersController(ICargoCustomerService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult CargoCustomerList()
        {
            var result = _service.TGetAll();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateCargoCustomer(CreateCargoCustomerDto dto)
        {
            var createCargoCustomer = new CargoCustomer
            {
                Surname = dto.Surname,
                Adress = dto.Adress,
                City = dto.City,
                District = dto.District,
                Email = dto.Email,
                Name = dto.Name,
                Phone = dto.Phone
            };
            _service.TInsert(createCargoCustomer);
            return Ok("başarıyla eklendi");
        }

        [HttpDelete]
        public IActionResult DeleteCargoCustomer(int id)
        {
            _service.TDelete(id);
            return Ok("başarılı silindi");
        }

        [HttpGet("{id}")]
        public IActionResult GetCargoCustomerById(int id)
        {
            var result = _service.TGetById(id);
            return Ok(result);
        }

        [HttpPut]
        public IActionResult UpdateCargoCustomer(UpdateCargoCustomerDt dto)
        {
            var updateCargoCustomer = new CargoCustomer
            {
                Surname=dto.Surname,
                Adress=dto.Adress,
                CargoCustomerId=dto.CargoCustomerId,
                City=dto.City,
                District=dto.District,
                Email=dto.Email,
                Name=dto.Name,
                Phone=dto.Phone
            };
            _service.TUpdate(updateCargoCustomer);
            return Ok("başarıyla güncellendi");
        }
    }
}
