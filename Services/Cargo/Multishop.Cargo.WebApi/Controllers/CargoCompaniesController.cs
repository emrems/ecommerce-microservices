using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Multishop.Cargo.BusinessLayer.Abstract;
using Multishop.Cargo.DtosLayer.Dtos.CargoCompanyDtos;
using Multishop.Cargo.EntityLayer.Concrate;

namespace Multishop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCompaniesController : ControllerBase
    {
        private readonly ICargoCompanyService _service;

        public CargoCompaniesController(ICargoCompanyService service)
        {
            _service = service;
        }
        [HttpGet]
        public  IActionResult CargoCompanyList()
        {
            var result = _service.TGetAll();
            return Ok(result);
        }

        [HttpPost]
        public  IActionResult CreateCargoCompany(CreateCargoCompanyDto dto)
        {
            var cargoCompany = new CargoCompany
            {
                CargoCompanyName = dto.CargoCompanyName
            };
             _service.TInsert(cargoCompany);
            return Ok("başarıyla eklendi");
        }

        [HttpDelete]
        public IActionResult DeleteCargoCompany(int id)
        {
            _service.TDelete(id);
            return Ok("başarılı silindi");
        }

        [HttpGet("{id}")]
        public  IActionResult GetCargoCompanyById(int id)
        {
            var result = _service.TGetById(id);
            return Ok(result);
        }

        [HttpPut]
        public IActionResult UpdateCargoCompany(UpdateCargoCompanyDto dto)
        {
            var updateCargoCompany = new CargoCompany
            {
                CargoCompanyId = dto.CargoCompanyId,
                CargoCompanyName = dto.CargoCompanyName
            };
             _service.TUpdate(updateCargoCompany);
            return Ok("başarıyla güncellendi");
        }
    }
}
