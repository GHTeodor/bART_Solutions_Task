using bARTSolutionTask.Domain.Models;
using bARTSolutionTask.Infrastructure.DTOs;

namespace bARTSolutionTask.Infrastructure.Services.Interfaces;

public interface IContactService
{
    Task<ICollection<Contact>> GetAllAsync(CancellationToken token = default);
    Task<Contact> CreateAsync(CreateContactDto contactDto, CancellationToken token = default);
    Task<UpdateContactDto> UpdateAccountIdAsync(Guid id, UpdateContactDto contactDto, CancellationToken token = default);
}