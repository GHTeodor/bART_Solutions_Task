using bARTSolutionTask.Domain.Models;

namespace bARTSolutionTask.Infrastructure.Repositories.Interfaces;

public interface IAccountRepository
{
    Task<ICollection<Account>> GetAllAsync(CancellationToken token = default);
    Task<Account?> GetByNameAsync(string name, CancellationToken token = default);
    Task CreateAsync(Account account, CancellationToken token = default);
}