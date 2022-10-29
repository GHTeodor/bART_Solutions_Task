using bARTSolutionTask.Infrastructure.DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace bARTSolutionTask.Infrastructure;

public static class DbContextExtensions
{
    public static void AddDbContextCustom(this IServiceCollection services, IConfiguration builder)
    {
        services.AddDbContext<DBContext>(o =>
            o.UseSqlServer(builder.GetConnectionString("MyDBConnection"),
                b => b.MigrationsAssembly("bARTSolutionTask")));
    }
}