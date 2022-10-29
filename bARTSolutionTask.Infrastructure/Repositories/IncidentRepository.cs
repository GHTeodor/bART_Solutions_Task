using bARTSolutionTask.Domain.Models;
using bARTSolutionTask.Infrastructure.DbContext;
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

    public async Task<ICollection<Incident>> GetAllAsync(CancellationToken token = default)
    {
        return await _dbContext.Incidents.ToListAsync(token);
    }

    public async Task<Incident?> GetByIdAsync(string id, CancellationToken token = default)
    {
        return await _dbContext
            .Incidents
            .Include(i => i.Accounts)
            .ThenInclude(i => i.Contacts)
            .SingleOrDefaultAsync(i => i.Name == id, token);
    }

    public async Task CreateOneAsync(Incident incident, CancellationToken token = default)
    {
        await _dbContext.Incidents.AddAsync(incident, token);
        if (incident.Accounts.Any())
        {
            foreach (var incidentAccount in incident.Accounts)
            {
                await _dbContext.Accounts.AddAsync(incidentAccount, token);

                if (incidentAccount.Contacts.Any())
                {
                    foreach (var accountContact in incidentAccount.Contacts)
                    {
                        await _dbContext.Contacts.AddAsync(accountContact, token);
                    }
                }
            }
        }
    }

    public async Task DeleteByIdAsync(string id, CancellationToken token = default)
    {
        _dbContext.Incidents.Remove(await GetByIdAsync(id));
    }
}