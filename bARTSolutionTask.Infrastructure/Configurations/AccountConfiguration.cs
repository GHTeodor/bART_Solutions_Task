using bARTSolutionTask.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace bARTSolutionTask.Infrastructure.Configurations;

public class AccountConfiguration : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.Property(f => f.Name)
            .IsRequired();

        builder.HasMany(f => f.Contacts)
            .WithOne(f => f.Account)
            .IsRequired()
            .HasForeignKey(f => f.AccountId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(f => f.Incident)
            .WithMany(f => f.Accounts)
            .IsRequired()
            .HasForeignKey(f => f.IncidentId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}