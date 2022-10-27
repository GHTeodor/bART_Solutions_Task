namespace bARTSolutionTask.Infrastructure.Repositories.Interfaces;

public interface IAccountRepository
{
    Task<object?> GetAllAsync();
}