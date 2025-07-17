using System.Text;
using System.Text.Json;
using LoanService.Application.Services;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace LoanService.Api.Messaging;

public class LoanCreatedWorker : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;
    private readonly string _host;
    private readonly string _queue;

    public LoanCreatedWorker(IServiceProvider serviceProvider, string host, string queue)
    {
        _serviceProvider = serviceProvider;
        _host = host;
        _queue = queue;
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var factory = new ConnectionFactory { HostName = _host };
        var connection = factory.CreateConnection();
        var channel = connection.CreateModel();
        channel.QueueDeclare(queue: _queue, durable: false, exclusive: false, autoDelete: false, arguments: null);
        var consumer = new EventingBasicConsumer(channel);
        consumer.Received += async (model, ea) =>
        {
            var body = ea.Body.ToArray();
            var message = JsonSerializer.Deserialize<LoanCreatedMessage>(Encoding.UTF8.GetString(body));
            if (message != null)
            {
                using var scope = _serviceProvider.CreateScope();
                var loanService = scope.ServiceProvider.GetRequiredService<ILoanService>();
                await loanService.MarkLoanAsSentAsync(message.LoanId);
            }
        };
        channel.BasicConsume(queue: _queue, autoAck: true, consumer: consumer);
        return Task.CompletedTask;
    }
} 