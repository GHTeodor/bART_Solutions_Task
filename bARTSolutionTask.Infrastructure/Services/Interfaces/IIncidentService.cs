using bARTSolutionTask.Domain.Models;
using bARTSolutionTask.Infrastructure.DTOs;

namespace bARTSolutionTask.Infrastructure.Services.Interfaces;

public interface IIncidentService
{
    Task<ICollection<Incident>> GetAllAsync(CancellationToken token = default);
    Task<Incident> CreateOneAsync(CreateIncidentDto incident, CancellationToken token = default);
    Task<Incident> GetByIdAsync(string id, CancellationToken token = default);
    Task DeleteByIdAsync(string id, CancellationToken token = default);
}