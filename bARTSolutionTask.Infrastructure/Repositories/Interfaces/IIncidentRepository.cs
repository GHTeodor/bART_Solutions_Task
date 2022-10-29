using bARTSolutionTask.Domain.Models;

namespace bARTSolutionTask.Infrastructure.Repositories.Interfaces;

public interface IIncidentRepository
{
    Task<ICollection<Incident>> GetAllAsync(CancellationToken token = default);
    Task<Incident?> GetByIdAsync(string id, CancellationToken token = default);
    Task CreateOneAsync(Incident incident, CancellationToken token = default);
    Task DeleteByIdAsync(string id, CancellationToken token = default);
}