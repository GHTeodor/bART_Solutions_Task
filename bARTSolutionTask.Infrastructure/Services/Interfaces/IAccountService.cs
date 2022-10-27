namespace bARTSolutionTask.Infrastructure.Services.Interfaces;

public interface IAccountService
{
    Task<object?> GetAllAsync();
}