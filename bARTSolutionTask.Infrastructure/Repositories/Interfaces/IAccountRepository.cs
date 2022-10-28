using bARTSolutionTask.Domain.Models;

namespace bARTSolutionTask.Infrastructure.Repositories.Interfaces;

public interface IAccountRepository
{
    Task<ICollection<Account>> GetAllAsync();
    Task<object?> GetByNameAsync(string name);
    Task CreateAsync(Account account);
}