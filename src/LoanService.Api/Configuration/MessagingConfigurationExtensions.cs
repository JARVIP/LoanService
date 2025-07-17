using LoanService.Api.Messaging;

namespace LoanService.Api.Configuration;

public static class MessagingConfigurationExtensions
{
    public static IServiceCollection AddMessaging(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IMessageQueueSender>(sp =>
            new RabbitMqMessageQueueSender(
                configuration["RabbitMq:Host"] ?? "rabbitmq",
                configuration["RabbitMq:LoanCreatedQueue"] ?? "loan-created"
            ));
        services.AddHostedService<LoanCreatedWorker>(sp =>
            new LoanCreatedWorker(
                sp,
                configuration["RabbitMq:Host"] ?? "rabbitmq",
                configuration["RabbitMq:LoanCreatedQueue"] ?? "loan-created"
            ));
        return services;
    }
} 