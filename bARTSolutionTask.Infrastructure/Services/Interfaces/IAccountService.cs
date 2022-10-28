using bARTSolutionTask.Domain.Models;
using bARTSolutionTask.Infrastructure.DTOs;

namespace bARTSolutionTask.Infrastructure.Services.Interfaces;

public interface IAccountService
{
    Task<ICollection<Account>> GetAllAsync();
    Task<object?> CreateAsync(CreateAccountDto account);
    Task<object?> GetByNameAsync(string name);
}