using bARTSolutionTask.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace bART_Solutions_Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncidentController : ControllerBase
    {
        private readonly IIncidentService _incidentService;

        public IncidentController(IIncidentService incidentService)
        {
            _incidentService = incidentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await _incidentService.Get());
        }
    }
}
