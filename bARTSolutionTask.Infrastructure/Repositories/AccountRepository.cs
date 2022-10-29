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

    public async Task<ICollection<Account>> GetAllAsync(CancellationToken token = default)
    {
        return await _dbContext.Accounts.ToListAsync(token);
    }

    public async Task<Account?> GetByNameAsync(string name, CancellationToken token = default)
    {
        return await _dbContext.Accounts.Include(a => a.Contacts)
            .SingleOrDefaultAsync(a => a.Name.ToUpper() == name.ToUpper(), token);
    }

    public async Task CreateAsync(Account account, CancellationToken token = default)
    {
        await _dbContext.Accounts.AddAsync(account, token);
        if (account.Contacts.Any())
        {
            foreach (var contact in account.Contacts)
            {
                await _dbContext.Contacts.AddAsync(contact, token);
            }
        }
    }
}