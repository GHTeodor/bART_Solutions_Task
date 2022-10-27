using bARTSolutionTask.Infrastructure.Repositories.Interfaces;
using bARTSolutionTask.Infrastructure.Services.Interfaces;

namespace bARTSolutionTask.Infrastructure.Services;

public class AccountService: IAccountService
{
    private readonly IAccountRepository _accountRepository;

    public AccountService(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }

    public async Task<object?> GetAllAsync()
    {
        return await _accountRepository.GetAllAsync();
    }
}