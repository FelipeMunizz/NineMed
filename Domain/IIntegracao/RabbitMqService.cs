using Helper.Configuracoes;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Domain.IIntegracao;

public class RabbitMqService
{
    private readonly string _hostname;
    private readonly string _queueName;
    private readonly string _username;
    private readonly string _password;

    public RabbitMqService(string queueName)
    {
        _hostname = RabbitMQConfigure.HostName;
        _username = RabbitMQConfigure.UserName;
        _password = RabbitMQConfigure.Password;
        _queueName = queueName;
    }

    public bool SendMessage<T>(T message)
    {
        try
        {
            ConnectionFactory factory = new ConnectionFactory
            {
                HostName = _hostname,
                UserName = _username,
                Password = _password,
            };

            using IConnection connection = factory.CreateConnection();
            using IModel channel = connection.CreateModel();

            channel.QueueDeclare(
                queue: _queueName,
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null
            );

            string messageBody = JsonSerializer.Serialize(message);
            byte[] encodingMessage = Encoding.UTF8.GetBytes(messageBody);

            channel.BasicPublish(
                exchange: string.Empty,
                routingKey: _queueName,
                basicProperties: null,
                body: encodingMessage
            );

            return true;
        }
        catch
        {
            return false;
        }
    }
}
