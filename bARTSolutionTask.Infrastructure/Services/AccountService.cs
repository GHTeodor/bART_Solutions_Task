using AutoMapper;
using bARTSolutionTask.Domain.Models;
using bARTSolutionTask.Infrastructure.DTOs;
using bARTSolutionTask.Infrastructure.Repositories.Interfaces;
using bARTSolutionTask.Infrastructure.Services.Interfaces;

namespace bARTSolutionTask.Infrastructure.Services;

public class AccountService: IAccountService
{
    private readonly IAccountRepository _accountRepository;
    private readonly IMapper _mapper;
    public AccountService(IAccountRepository accountRepository, IMapper mapper)
    {
        _accountRepository = accountRepository;
        _mapper = mapper;
    }

    public async Task<ICollection<Account>> GetAllAsync()
    {
        return await _accountRepository.GetAllAsync();
    }

    public async Task<object?> GetByNameAsync(string name)
    {
        return await _accountRepository.GetByNameAsync(name);
    }

    public async Task<object?> CreateAsync(CreateAccountDto accountDto)
    {
        Account account = _mapper.Map<Account>(accountDto);
        await _accountRepository.CreateAsync(account);
        return account;
    }
}