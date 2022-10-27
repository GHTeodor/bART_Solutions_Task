using bARTSolutionTask.Infrastructure.Repositories;
using bARTSolutionTask.Infrastructure.Repositories.Interfaces;
using bARTSolutionTask.Infrastructure.Services;
using bARTSolutionTask.Infrastructure.Services.Interfaces;

namespace bARTSolutionTask.Configurations;

public static class ServiceManager
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IAccountService, AccountService>();
        services.AddScoped<IContactService, ContactService>();
        services.AddScoped<IIncidentService, IncidentService>();

        services.AddScoped<IAccountRepository, AccountRepository>();
        services.AddScoped<IContactRepository, ContactRepository>();
        services.AddScoped<IIncidentRepository, IncidentRepository>();
    }
}