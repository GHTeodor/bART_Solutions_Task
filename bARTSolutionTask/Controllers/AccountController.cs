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
        public async Task<IActionResult> GetAllAsync(CancellationToken token = default)
        {
            return Ok(await _accountService.GetAllAsync(token));
        }

        [HttpGet("[action]/{name}")]
        public async Task<IActionResult> GetByNameWithDetailsAsync(string name, CancellationToken token = default)
        {
            var account = await _accountService.GetByNameAsync(name, token);
            if (account is null)
            {
                return NotFound();
            }

            return Ok(account);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateAccountDto account,
            CancellationToken token = default)
        {
            return Ok(await _accountService.CreateAsync(account, token));
        }
    }
}