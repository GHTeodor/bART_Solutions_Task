using bARTSolutionTask.Domain.Models;
using bARTSolutionTask.Infrastructure.DbContext;
using bARTSolutionTask.Infrastructure.DTOs;
using bARTSolutionTask.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace bARTSolutionTask.Infrastructure.Repositories;

public class ContactRepository : IContactRepository
{
    private readonly DBContext _dbContext;

    public ContactRepository(DBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ICollection<Contact>> GetAllAsync(CancellationToken token = default)
    {
        return await _dbContext.Contacts.ToListAsync(token);
    }

    public async Task CreateAsync(Contact contact, CancellationToken token = default)
    {
        await _dbContext.Contacts.AddAsync(contact, token);
    }

    public async Task<Contact> GetContactByIdAsync(Guid id, CancellationToken token = default)
    {
        return await _dbContext.Contacts.SingleOrDefaultAsync(c => c.Id == id, token);
    }

    public async Task UpdateAccountIdAsync(Contact contact)
    {
        await Task.FromResult(_dbContext.Contacts.Update(contact));
    }
}