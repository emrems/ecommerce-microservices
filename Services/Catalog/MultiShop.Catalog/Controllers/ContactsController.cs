using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ContactDtos;
using MultiShop.Catalog.Services.ContactServices;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _contactService;
        public ContactsController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllContact()
        {
            var result = await _contactService.GetAllContactAsync();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetContactById(string id)
        {
            var result = await _contactService.GetByIdContactAsync(id);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateContact(CreateContactDto dto)
        {
            await _contactService.CreateContactAsync(dto);
            return Ok("contact başarılı bir şekilde eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteContactById(string id)
        {
            await _contactService.DeleteContactAsync(id);
            return Ok("Contact silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateContact(UpdateContactDto dto)
        {
            await _contactService.UpdateContactAsync(dto);
            return Ok("Contact güncellendi");
        }


    }
}
