using bARTSolutionTask.Domain.Models;
using bARTSolutionTask.Infrastructure.DbContext;
using bARTSolutionTask.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace bARTSolutionTask.Infrastructure.Repositories;

public class AccountRepository : IAccountRepository
{
    private readonly DBContext _dbContext;

    public AccountRepository(DBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ICollection<Account>> GetAllAsync()
    {
        return await _dbContext.Accounts.ToListAsync();
    }

    public async Task<object?> GetByNameAsync(string name)
    {
        return await _dbContext.Accounts.SingleOrDefaultAsync(a => a.Name.ToUpper() == name.ToUpper());
    }

    public async Task CreateAsync(Account account)
    {
        await _dbContext.Accounts.AddAsync(account);
        if (account.Contacts.Any())
        {
            foreach (var contact in account.Contacts)
            {
                await _dbContext.Contacts.AddAsync(contact);
            }
        }
        
        await _dbContext.SaveChangesAsync();
        await _dbContext.DisposeAsync();
    }
}