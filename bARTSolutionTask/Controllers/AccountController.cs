using bARTSolutionTask.Domain.Models;
using bARTSolutionTask.Infrastructure.DTOs;
using bARTSolutionTask.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace bARTSolutionTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _accountService.GetAllAsync());
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetByNameAsync(string name)
        {
            var account = await _accountService.GetByNameAsync(name);
            if (account is null)
            {
                return NotFound();
            }
            return Ok(account);
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateAccountDto account)
        {
            return Ok(await _accountService.CreateAsync(account));
        }
    }
}
