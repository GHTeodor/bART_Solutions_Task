using bARTSolutionTask.Domain.Models;
using bARTSolutionTask.Infrastructure.DTOs;
using bARTSolutionTask.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace bARTSolutionTask.Controllers
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
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _incidentService.GetAllAsync());
        }
        
        [HttpGet("{id:length(36)}")]
        public async Task<IActionResult> GetByIdAsync(string id)
        {
            return Ok(await _incidentService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateOneAsync([FromBody] CreateIncidentDto incident)
        {
            return Ok(await _incidentService.CreateOneAsync(incident));
        }

        [HttpDelete("{id:length(36)}")]
        public async Task<IActionResult> DeleteByIdAsync(string id)
        {
            await _incidentService.DeleteByIdAsync(id);
            return Ok();
        }
    }
}
