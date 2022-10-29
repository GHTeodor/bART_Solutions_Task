using AutoMapper;
using bARTSolutionTask.Domain.Models;
using bARTSolutionTask.Infrastructure.DTOs;
using bARTSolutionTask.Infrastructure.Repositories.Interfaces;
using bARTSolutionTask.Infrastructure.Services.Interfaces;
using bARTSolutionTask.Infrastructure.UnitOfWork.Interfaces;

namespace bARTSolutionTask.Infrastructure.Services;

public class AccountService: IAccountService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public AccountService(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<ICollection<Account>> GetAllAsync(CancellationToken token = default)
    {
        return await _unitOfWork.Accounts.GetAllAsync(token);
    }

    public async Task<Account?> GetByNameAsync(string name, CancellationToken token = default)
    {
        return await _unitOfWork.Accounts.GetByNameAsync(name, token);
    }

    public async Task<Account> CreateAsync(CreateAccountDto accountDto, CancellationToken token = default)
    {
        Account account = _mapper.Map<Account>(accountDto);
        
        await _unitOfWork.Accounts.CreateAsync(account, token);
        await _unitOfWork.SaveAsync(token);
        await _unitOfWork.DisposeAsync();
        
        return account;
    }
}