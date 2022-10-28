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

    public async Task<object?> GetAllAsync()
    {
        return await _dbContext.Contacts.ToListAsync();
    }

    public async Task CreateAsync(Contact contact)
    {
        await _dbContext.Contacts.AddAsync(contact);
        await _dbContext.SaveChangesAsync();
        await _dbContext.DisposeAsync();
    }

    public async Task UpdateAccountIdAsync(Guid id, UpdateContactDto contactDto)
    {
        Contact contact = await _dbContext.Contacts.SingleOrDefaultAsync(c => c.Id == id);
        if (contact is not null)
        {
            contact.AccountId = contactDto.AccountId;
            _dbContext.Contacts.Update(contact);
            await _dbContext.SaveChangesAsync();
        }
        await _dbContext.DisposeAsync();
    }
}