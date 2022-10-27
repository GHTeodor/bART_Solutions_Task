using bARTSolutionTask.Domain.Models;

namespace bARTSolutionTask.Infrastructure.Repositories.Interfaces;

public interface IIncidentRepository
{
    Task<object?> GetAllAsync();
    Task<Incident?> GetByIdAsync(string id);
    Task CreateOneAsync(Incident incident);
    Task DeleteByIdAsync(string id);
}