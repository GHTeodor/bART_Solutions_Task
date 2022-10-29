using System.ComponentModel.DataAnnotations;

namespace bARTSolutionTask.Domain.Models;

public abstract class BaseEntity
{
    [Key]
    public Guid Id { get; set; }
}