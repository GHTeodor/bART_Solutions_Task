using System.ComponentModel.DataAnnotations;
using bARTSolutionTask.Infrastructure.DbModelValidation;

namespace bARTSolutionTask.Infrastructure.DTOs;

public class ContactDto : BaseEntityDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
}

public class CreateContactDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    [EmailAddress] 
    [UniqEmail]
    public string Email { get; set; }
}