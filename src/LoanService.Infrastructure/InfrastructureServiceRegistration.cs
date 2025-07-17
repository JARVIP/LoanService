using LoanService.Domain.Repositories;
using LoanService.Infrastructure.Data;
using LoanService.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LoanService.Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection ConfigureInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<LoanDbContext>(options =>
           options.UseSqlServer(
               configuration.GetConnectionString("LoanDb")));

        services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        
        return services;
    }
}
