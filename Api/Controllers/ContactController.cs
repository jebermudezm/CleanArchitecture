using Api.Middleware;
using Application.Dto;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ContactDto))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(ErrorDetails))]
        public async Task<IActionResult> Get()
        {
            return Ok(await _contactService.GetAll());
        }
        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ContactDto))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(ErrorDetails))]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _contactService.GetById(id));
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(List<ContactDto>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(ErrorDetails))]
        [ProducesResponseType((int)HttpStatusCode.UnprocessableEntity, Type = typeof(ErrorDetails))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(ErrorDetails))]
        public async Task<IActionResult> Post(ContactDto contact)
        {
            return Ok(await _contactService.Create(contact));
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(List<ContactDto>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(ErrorDetails))]
        [ProducesResponseType((int)HttpStatusCode.UnprocessableEntity, Type = typeof(ErrorDetails))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(ErrorDetails))]
        public async Task<IActionResult> Put(ContactDto contact)
        {
            return Ok(await _contactService.Update(contact));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(List<ContactDto>))]
        [ProducesResponseType((int)HttpStatusCode.UnprocessableEntity, Type = typeof(ErrorDetails))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(ErrorDetails))]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _contactService.Delete(id));
        }

    }
}
