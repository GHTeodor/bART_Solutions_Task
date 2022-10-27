using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace bARTSolutionTask.Domain.Models;

public class Contact : BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    [EmailAddress]
    public string Email { get; set; }
    public Guid AccountId { get; set; }
    public Account? Account { get; set; }
}