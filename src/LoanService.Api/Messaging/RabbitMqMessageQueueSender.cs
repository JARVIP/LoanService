using System.Text;
using System.Text.Json;
using RabbitMQ.Client;

namespace LoanService.Api.Messaging;

public class RabbitMqMessageQueueSender : IMessageQueueSender
{
    private readonly string _host;
    private readonly string _queue;

    public RabbitMqMessageQueueSender(string host, string queue)
    {
        _host = host;
        _queue = queue;
    }

    public void SendLoanCreated(LoanCreatedMessage message)
    {
        var factory = new ConnectionFactory { HostName = _host };
        using var connection = factory.CreateConnection();
        using var channel = connection.CreateModel();
        channel.QueueDeclare(queue: _queue, durable: false, exclusive: false, autoDelete: false, arguments: null);
        var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(message));
        channel.BasicPublish(exchange: "", routingKey: _queue, basicProperties: null, body: body);
    }
} 