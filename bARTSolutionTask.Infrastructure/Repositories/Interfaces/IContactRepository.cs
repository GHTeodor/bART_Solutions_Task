using bARTSolutionTask.Domain.Models;
using bARTSolutionTask.Infrastructure.DTOs;

namespace bARTSolutionTask.Infrastructure.Repositories.Interfaces;

public interface IContactRepository
{
    Task<ICollection<Contact>> GetAllAsync(CancellationToken token = default);
    Task CreateAsync(Contact contact, CancellationToken token = default);
    Task UpdateAccountIdAsync(Contact contactDto);
    Task<Contact> GetContactByIdAsync(Guid id, CancellationToken token = default);
}