using AsyncCommunication.Publisher.API.DTOs;
using AsyncCommunication.Publisher.API.Interfaces;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace AsyncCommunication.Publisher.API.Implementations;
public class EventBus : IEventBus
{
    private readonly IConfiguration _config;
    private readonly IConnection _connection;
    private readonly IModel _channel;

    public EventBus(IConfiguration configuration)
    {
        _config = configuration;
        var factory = new ConnectionFactory()
        {
            HostName = _config["RabbitMqHost"],
            Port = int.Parse(_config["RabbitMqPort"])
        };

        try
        {
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.ExchangeDeclare(exchange: "publisherService.fanout", 
                type: ExchangeType.Fanout);
            _connection.ConnectionShutdown += RabbitMq_ConnectionShutdown;

            Console.WriteLine("==> connected to Message bus");
        }
        catch (Exception ex)
        {

            Console.WriteLine($"==> could not connect to the Message bus : {ex.Message}");
        }
    }

    private void RabbitMq_ConnectionShutdown(object? sender, ShutdownEventArgs e)
    {
        throw new NotImplementedException();
    }

    public void PublishNewMessage(PubToSubMessage pubToSubMessage)
    {
        var message = JsonSerializer.Serialize(pubToSubMessage);

        if (_connection.IsOpen)
        {
            Console.WriteLine("==> Sending Message...");

            SendMessage(message);
        }
        else
        {
            Console.WriteLine("==> Connection closed, Message not sent.");
        }
    }

    private void SendMessage(string message)
    {
        var body = Encoding.UTF8.GetBytes(message);

        _channel.BasicPublish(
            exchange: "publisherService.fanout",
            routingKey: "",
            basicProperties: null,
            body: body);
        Console.WriteLine("==> Message sent.");
    }

    public void Dispose()
    {
        Console.WriteLine("Message bus closed.");
        if (_connection.IsOpen)
        {
            _channel.Close();
            _connection.Close();
        }
    }
}
