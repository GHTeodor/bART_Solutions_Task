using System.Text.Json;
using bARTSolutionTask.Infrastructure.DbContext;
using bARTSolutionTask.Infrastructure.Repositories;
using bARTSolutionTask.Infrastructure.Repositories.Interfaces;
using bARTSolutionTask.Infrastructure.UnitOfWork.Interfaces;

namespace bARTSolutionTask.Infrastructure.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly DBContext _dbContext;

    public UnitOfWork(DBContext dbContext)
    {
        _dbContext = dbContext;
        Accounts = new AccountRepository(_dbContext);
        Contacts = new ContactRepository(_dbContext);
        Incidents = new IncidentRepository(_dbContext);
    }

    public IAccountRepository Accounts { get; }
    public IContactRepository Contacts { get; }
    public IIncidentRepository Incidents { get; }

    public async Task SaveAsync(CancellationToken token = default)
    {
        await _dbContext.SaveChangesAsync(token);
    }

    private Utf8JsonWriter? _jsonWriter = new(new MemoryStream());

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

    public async ValueTask DisposeAsync()
    {
        await DisposeAsyncCore().ConfigureAwait(false);

        Dispose(disposing: false);
#pragma warning disable CA1816 // Dispose methods should call SuppressFinalize
        GC.SuppressFinalize(this);
#pragma warning restore CA1816 // Dispose methods should call SuppressFinalize
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            _jsonWriter?.Dispose();
            _jsonWriter = null;
        }
    }

    protected virtual async ValueTask DisposeAsyncCore()
    {
        if (_jsonWriter is not null)
        {
            await _jsonWriter.DisposeAsync().ConfigureAwait(false);
        }

        _jsonWriter = null;
    }
}