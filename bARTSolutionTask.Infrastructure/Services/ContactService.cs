using AutoMapper;
using bARTSolutionTask.Domain.Models;
using bARTSolutionTask.Infrastructure.DTOs;
using bARTSolutionTask.Infrastructure.Repositories;
using bARTSolutionTask.Infrastructure.Repositories.Interfaces;
using bARTSolutionTask.Infrastructure.Services.Interfaces;

namespace bARTSolutionTask.Infrastructure.Services;

public class ContactService : IContactService
{
    private readonly IContactRepository _contactRepository;
    private readonly IMapper _mapper;

    public ContactService(IContactRepository contactRepository, IMapper mapper)
    {
        _contactRepository = contactRepository;
        _mapper = mapper;
    }

    public async Task<object?> GetAllAsync()
    {
        return await _contactRepository.GetAllAsync();
    }

    public async Task<object?> CreateAsync(CreateContactDto contactDto)
    {
        Contact contact = _mapper.Map<Contact>(contactDto);
        await _contactRepository.CreateAsync(contact);
        return contact;
    }

    public async Task<object?> UpdateAccountIdAsync(Guid id, UpdateContactDto contactDto)
    {
        await _contactRepository.UpdateAccountIdAsync(id, contactDto);
        return contactDto;
    }
}