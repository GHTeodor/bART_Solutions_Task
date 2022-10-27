using bARTSolutionTask.Infrastructure.DbContext;
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
}