using bARTSolutionTask.Infrastructure.DTOs;

namespace bARTSolutionTask.Infrastructure.Services.Interfaces;

public interface IContactService
{
    Task<object?> GetAllAsync();
    Task<object?> CreateAsync(CreateContactDto contactDto);
    Task<object?> UpdateAccountIdAsync(Guid id, UpdateContactDto contactDto);
}