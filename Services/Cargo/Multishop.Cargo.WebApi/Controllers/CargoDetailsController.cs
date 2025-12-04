using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Multishop.Cargo.BusinessLayer.Abstract;
using Multishop.Cargo.DtosLayer.Dtos.CargoCompanyDtos;
using Multishop.Cargo.DtosLayer.Dtos.CargoDetailsDtos;
using Multishop.Cargo.EntityLayer.Concrate;

namespace Multishop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoDetailsController : ControllerBase
    {
        private readonly ICargoDetailService _service;

        public CargoDetailsController(ICargoDetailService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult CargoDetailList()
        {
            var result = _service.TGetAll();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateCargoDetail(CreateCargoDetailDto dto)
        {
            var cargoDetail = new CargoDetail
            {
                Barcode=dto.Barcode,
                SenderCustomer=dto.SenderCustomer,
                ReciverCustomer=dto.ReciverCustomer,
                CargoCompanyId=dto.CargoCompanyId
            };
            _service.TInsert(cargoDetail);
            return Ok("başarıyla eklendi");
        }

        [HttpDelete]
        public IActionResult DeleteCargoDetail(int id)
        {
            _service.TDelete(id);
            return Ok("başarılı silindi");
        }

        [HttpGet("{id}")]
        public IActionResult GetCargoDetailById(int id)
        {
            var result = _service.TGetById(id);
            return Ok(result);
        }

        [HttpPut]
        public IActionResult UpdateCargoDetail(UpdateCargoDetailDto dto)
        {
            var cargoDetail = new CargoDetail
            {
                CargoDetailId=dto.CargoDetailId,
                Barcode = dto.Barcode,
                SenderCustomer = dto.SenderCustomer,
                ReciverCustomer = dto.ReciverCustomer,
                CargoCompanyId = dto.CargoCompanyId
            };
            _service.TUpdate(cargoDetail);
            return Ok("başarıyla güncellendi");
        }
    }
}
