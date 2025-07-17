using Serilog;

namespace LoanService.Api.Configuration;

public static class LoggingConfigurationExtensions
{
    public static IHostBuilder UseSerilogLogging(this IHostBuilder hostBuilder, IConfiguration configuration)
    {
        Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(configuration)
            .Enrich.FromLogContext()
            .CreateLogger();

        hostBuilder.UseSerilog();
        return hostBuilder;
    }
} 