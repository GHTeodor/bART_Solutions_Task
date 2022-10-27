using bARTSolutionTask.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace bARTSolutionTask.Infrastructure.Configurations;

public class ContactConfiguration : IEntityTypeConfiguration<Contact>
{
    public void Configure(EntityTypeBuilder<Contact> builder)
    {
        builder.Property(f => f.FirstName)
            .IsRequired();

        builder.Property(f => f.LastName)
            .IsRequired();

        builder.Property(f => f.Email)
            .IsRequired();

        builder.HasOne(f => f.Account)
            .WithMany(f => f.Contacts)
            .IsRequired()
            .HasForeignKey(f => f.AccountId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}