using bARTSolutionTask.Infrastructure.Repositories.Interfaces;

namespace bARTSolutionTask.Infrastructure.UnitOfWork.Interfaces;

public interface IUnitOfWork : IAsyncDisposable, IDisposable
{
    IAccountRepository Accounts { get; }
    IContactRepository Contacts { get; }
    IIncidentRepository Incidents { get; }
    Task SaveAsync(CancellationToken token = default);
}