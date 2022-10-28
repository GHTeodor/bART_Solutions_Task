using bARTSolutionTask.Infrastructure.DTOs;
using bARTSolutionTask.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace bARTSolutionTask.Controllers
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
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _contactService.GetAllAsync());
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateContactDto contactDto)
        {
            return Ok(await _contactService.CreateAsync(contactDto));
        }

        [HttpPatch("{id:guid}")]
        public async Task<IActionResult> UpdateAccountIdAsync(Guid id, [FromBody] UpdateContactDto contactDto)
        {
            return Ok(await _contactService.UpdateAccountIdAsync(id, contactDto));
        }
    }
}
