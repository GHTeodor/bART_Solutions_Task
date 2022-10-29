using AutoMapper;
using bARTSolutionTask.Domain.Models;
using bARTSolutionTask.Infrastructure.DTOs;
using bARTSolutionTask.Infrastructure.Repositories.Interfaces;
using bARTSolutionTask.Infrastructure.Services.Interfaces;
using bARTSolutionTask.Infrastructure.UnitOfWork.Interfaces;

namespace bARTSolutionTask.Infrastructure.Services;

public class IncidentService: IIncidentService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public IncidentService(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<ICollection<Incident>> GetAllAsync(CancellationToken token = default)
    {
        return await _unitOfWork.Incidents.GetAllAsync(token);
    }

    public async Task<Incident> GetByIdAsync(string id, CancellationToken token = default)
    {
        return await _unitOfWork.Incidents.GetByIdAsync(id, token);
    }
    
    public async Task<Incident> CreateOneAsync(CreateIncidentDto incidentDto, CancellationToken token = default)
    {
        Incident incident = _mapper.Map<Incident>(incidentDto);
        
        await _unitOfWork.Incidents.CreateOneAsync(incident, token);
        await _unitOfWork.SaveAsync(token);
        await _unitOfWork.DisposeAsync();

        return incident;
    }

    public async Task DeleteByIdAsync(string id, CancellationToken token = default)
    {
        await _unitOfWork.Incidents.DeleteByIdAsync(id, token);
        await _unitOfWork.SaveAsync(token);
        await _unitOfWork.DisposeAsync();
    }
}