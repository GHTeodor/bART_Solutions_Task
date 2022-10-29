using AutoMapper;
using bARTSolutionTask.Domain.Models;
using bARTSolutionTask.Infrastructure.DTOs;
using bARTSolutionTask.Infrastructure.Repositories;
using bARTSolutionTask.Infrastructure.Repositories.Interfaces;
using bARTSolutionTask.Infrastructure.Services.Interfaces;
using bARTSolutionTask.Infrastructure.UnitOfWork.Interfaces;

namespace bARTSolutionTask.Infrastructure.Services;

public class ContactService : IContactService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ContactService(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<ICollection<Contact>> GetAllAsync(CancellationToken token = default)
    {
        return await _unitOfWork.Contacts.GetAllAsync(token);
    }

    public async Task<Contact> CreateAsync(CreateContactDto contactDto, CancellationToken token = default)
    {
        Contact contact = _mapper.Map<Contact>(contactDto);
        
        await _unitOfWork.Contacts.CreateAsync(contact, token);
        await _unitOfWork.SaveAsync(token);
        await _unitOfWork.DisposeAsync();
        
        return contact;
    }

    public async Task<UpdateContactDto> UpdateAccountIdAsync(Guid id, UpdateContactDto contactDto, CancellationToken token = default)
    {
        Contact contact = await _unitOfWork.Contacts.GetContactByIdAsync(id, token);
        if (contact is not null)
        {
            contact.AccountId = contactDto.AccountId;
            
            await _unitOfWork.Contacts.UpdateAccountIdAsync(contact);
            await _unitOfWork.SaveAsync(token);
            await _unitOfWork.DisposeAsync();
        }
        return contactDto;
    }
}