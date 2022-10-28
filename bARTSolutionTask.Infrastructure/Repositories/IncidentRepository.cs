using bARTSolutionTask.Domain.Models;
using bARTSolutionTask.Infrastructure.DbContext;
using bARTSolutionTask.Infrastructure.DTOs;
using bARTSolutionTask.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace bARTSolutionTask.Infrastructure.Repositories;

public class IncidentRepository : IIncidentRepository
{
    private readonly DBContext _dbContext;

    public IncidentRepository(DBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<object?> GetAllAsync()
    {
        return await _dbContext.Incidents.ToListAsync();
    }

    public async Task<Incident?> GetByIdAsync(string id)
    {
        return await _dbContext
            .Incidents
            .Include(i => i.Accounts)
            .ThenInclude(i => i.Contacts)
            .SingleOrDefaultAsync(i => i.Name == id);
    }

    public async Task CreateOneAsync(Incident incident)
    {
        await _dbContext.Incidents.AddAsync(incident);
        if (incident.Accounts.Any())
        {
            foreach (var incidentAccount in incident.Accounts)
            {
                await _dbContext.Accounts.AddAsync(incidentAccount);

                if (incidentAccount.Contacts.Any())
                {
                    foreach (var accountContact in incidentAccount.Contacts)
                    {
                        await _dbContext.Contacts.AddAsync(accountContact);
                    }
                }
            }
        }

        await _dbContext.SaveChangesAsync();
        await _dbContext.DisposeAsync();
    }

    public async Task DeleteByIdAsync(string id)
    {
        _dbContext.Incidents.Remove(await GetByIdAsync(id));
        await _dbContext.SaveChangesAsync();
        await _dbContext.DisposeAsync();
    }
}