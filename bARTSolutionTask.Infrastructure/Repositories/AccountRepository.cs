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

    public async Task<object?> GetAllAsync()
    {
        return await _dbContext.Accounts.ToListAsync();
    }
}