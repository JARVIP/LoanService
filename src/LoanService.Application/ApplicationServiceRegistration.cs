using LoanService.Application.Mappers;
using LoanService.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace LoanService.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
    {
        services.AddSingleton<IAuthMapper, AuthMapper>();
        services.AddSingleton<ILoanMapper, LoanMapper>();
        
        services.AddScoped<ILoanService, LoanManagementService>();
        return services;
    }
}
