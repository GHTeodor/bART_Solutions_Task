using AutoMapper;
using bARTSolutionTask.Domain.Models;
using bARTSolutionTask.Infrastructure.DTOs;
using bARTSolutionTask.Infrastructure.Repositories.Interfaces;
using bARTSolutionTask.Infrastructure.Services.Interfaces;

namespace bARTSolutionTask.Infrastructure.Services;

public class IncidentService: IIncidentService
{
    private readonly IIncidentRepository _incidentRepository;
    private readonly IMapper _mapper;

    public IncidentService(IIncidentRepository incidentRepository, IMapper mapper)
    {
        _incidentRepository = incidentRepository;
        _mapper = mapper;
    }

    public async Task<object?> GetAllAsync()
    {
        return await _incidentRepository.GetAllAsync();
    }

    public async Task<object?> GetByIdAsync(string id)
    {
        return await _incidentRepository.GetByIdAsync(id);
    }
    
    public async Task<Incident> CreateOneAsync(CreateIncidentDto incidentDto)
    {
        Incident incident = _mapper.Map<Incident>(incidentDto);
        await _incidentRepository.CreateOneAsync(incident);
        return incident;
    }

    public async Task DeleteByIdAsync(string id)
    {
        await _incidentRepository.DeleteByIdAsync(id);
    }
}