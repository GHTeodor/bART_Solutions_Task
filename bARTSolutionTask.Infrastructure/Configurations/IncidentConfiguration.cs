using bARTSolutionTask.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace bARTSolutionTask.Infrastructure.Configurations;

public class IncidentConfiguration: IEntityTypeConfiguration<Incident>
{
    public void Configure(EntityTypeBuilder<Incident> builder)
    {
        builder.Property(f => f.Name)
            .IsRequired();

        builder.Property(f => f.Description)
            .IsRequired();

        builder.HasMany(f => f.Accounts)
            .WithOne(f => f.Incident)
            .HasForeignKey(f => f.IncidentId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Cascade);
    }
}