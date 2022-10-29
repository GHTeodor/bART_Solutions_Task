using bARTSolutionTask.Infrastructure.DbModelValidation;

namespace bARTSolutionTask.Infrastructure.DTOs;

public class AccountDto : BaseEntityDto
{
    [UniqAccountName] 
    public string Name { get; set; }
    public string? IncidentId { get; set; }
    public ICollection<ContactDto> Contacts { get; set; }
}

public class CreateAccountDto
{
    [UniqAccountName] 
    public string Name { get; set; }
    public ICollection<CreateContactDto> Contacts { get; set; }
}
