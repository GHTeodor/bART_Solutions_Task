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
        public async Task<IActionResult> GetAllAsync(CancellationToken token = default)
        {
            return Ok(await _incidentService.GetAllAsync(token));
        }
        
        [HttpGet("[action]/{nameId:length(36)}")]
        public async Task<IActionResult> GetByIdWithDetailsAsync(string nameId, CancellationToken token = default)
        {
            var incident = await _incidentService.GetByIdAsync(nameId, token);
            if (incident is null)
            {
                return NotFound($"There is no incident with nameId: {nameId}");
            }
            return Ok(incident);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOneAsync([FromBody] CreateIncidentDto incident, CancellationToken token = default)
        {
            return Ok(await _incidentService.CreateOneAsync(incident, token));
        }

        [HttpDelete("{nameId:length(36)}")]
        public async Task<IActionResult> DeleteByIdAsync(string nameId, CancellationToken token = default)
        {
            try
            {
                await _incidentService.DeleteByIdAsync(nameId, token);
            }
            catch (ArgumentNullException e)
            {
                return NotFound($"Incident with nameId: {nameId} is not exist \n{e.Message}");
            }
            return Ok($"Incident with nameId: {nameId} successfully deleted");
        }
    }
}
