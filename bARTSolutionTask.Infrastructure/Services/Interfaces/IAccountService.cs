using bARTSolutionTask.Domain.Models;
using bARTSolutionTask.Infrastructure.DTOs;

namespace bARTSolutionTask.Infrastructure.Services.Interfaces;

public interface IAccountService
{
    Task<ICollection<Account>> GetAllAsync(CancellationToken token = default);
    Task<Account> CreateAsync(CreateAccountDto account, CancellationToken token = default);
    Task<Account?> GetByNameAsync(string name, CancellationToken token = default);
}