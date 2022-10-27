using bARTSolutionTask.Domain.Models;
using bARTSolutionTask.Infrastructure.DTOs;

namespace bARTSolutionTask.Infrastructure.Services.Interfaces;

public interface IIncidentService
{
    Task<object?> GetAllAsync();
    Task<Incident> CreateOneAsync(CreateIncidentDto incident);
    Task<object?> GetByIdAsync(string id);
    Task DeleteByIdAsync(string id);
}