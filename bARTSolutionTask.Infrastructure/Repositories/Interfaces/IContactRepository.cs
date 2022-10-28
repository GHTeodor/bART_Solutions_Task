using bARTSolutionTask.Domain.Models;
using bARTSolutionTask.Infrastructure.DTOs;

namespace bARTSolutionTask.Infrastructure.Repositories.Interfaces;

public interface IContactRepository
{
    Task<object?> GetAllAsync();
    Task CreateAsync(Contact contact);
    Task UpdateAccountIdAsync(Guid id, Contact contactDto);
    Task<Contact> GetContactByIdAsync(Guid id);
}