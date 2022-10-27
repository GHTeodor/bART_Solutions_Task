using System.Text.Json.Serialization;

namespace bARTSolutionTask.Domain.Models;

public class Account : BaseEntity
{
    public string Name { get; set; }
    public ICollection<Contact> Contacts { get; set; }
    public string IncidentId { get; set; }
    public Incident? Incident { get; set; }
}
