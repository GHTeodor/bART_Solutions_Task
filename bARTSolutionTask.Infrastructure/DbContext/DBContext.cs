using bARTSolutionTask.Domain.Models;
using bARTSolutionTask.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace bARTSolutionTask.Infrastructure.DbContext;

public class DBContext: Microsoft.EntityFrameworkCore.DbContext
{
    public DBContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new AccountConfiguration());
        modelBuilder.ApplyConfiguration(new IncidentConfiguration());
        modelBuilder.ApplyConfiguration(new ContactConfiguration());
    }
    
    public DbSet<Incident> Incidents { get; set; }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Contact> Contacts { get; set; }
}