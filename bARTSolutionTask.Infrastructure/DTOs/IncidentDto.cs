namespace bARTSolutionTask.Infrastructure.DTOs;

public class IncidentDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public ICollection<AccountDto> Accounts { get; set; }
}

public class CreateIncidentDto
{
    public string Description { get; set; }
    public ICollection<CreateAccountDto> Accounts { get; set; }
}