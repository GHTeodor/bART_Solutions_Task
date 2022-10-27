namespace bARTSolutionTask.Infrastructure.Repositories.Interfaces;

public interface IContactRepository
{
    Task<object?> GetAllAsync();
}