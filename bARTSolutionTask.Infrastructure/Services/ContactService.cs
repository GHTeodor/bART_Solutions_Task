using bARTSolutionTask.Infrastructure.Repositories;
using bARTSolutionTask.Infrastructure.Repositories.Interfaces;
using bARTSolutionTask.Infrastructure.Services.Interfaces;

namespace bARTSolutionTask.Infrastructure.Services;

public class ContactService : IContactService
{
    private readonly IContactRepository _contactRepository;

    public ContactService(IContactRepository contactRepository)
    {
        _contactRepository = contactRepository;
    }

    public async Task<object?> GetAllAsync()
    {
        return await _contactRepository.GetAllAsync();
    }
}