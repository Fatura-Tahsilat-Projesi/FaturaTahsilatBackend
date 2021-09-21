using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicrosoftOrnekBackendUyg.RabbitMQ
{
    public class RabbitMQClientService:IDisposable
    {
        private readonly ConnectionFactory _connectionFactory;
        private IConnection _connection;
        private IModel _channel;
        public static string ExchangeName = "PaymentDirectExchange";
        public static string Routing = "payment-route-credit";
        public static string QueueName = "credit-card-payment";

        //private readonly ILogger<RabbitMQClientService> _logger;

        public RabbitMQClientService(ConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
            //_logger = logger;
        }

        public IModel Connect()
        {
            _connection = _connectionFactory.CreateConnection();

            //if(_channel.IsOpen==true)
            if (_channel is { IsOpen: true })
            {
                return _channel;
            }

            _channel = _connection.CreateModel();

            _channel.ExchangeDeclare(ExchangeName, type: "direct", true, false);

            _channel.QueueDeclare(QueueName, true, false, false, null);
            _channel.QueueBind(exchange: ExchangeName, queue: QueueName, routingKey: Routing);

            //_channel.QueueDeclare(QueueNameMobile, true, false, false, null);
            //_channel.QueueBind(exchange: ExchangeName, queue: QueueNameMobile, routingKey: Routing);

            //_channel.QueueDeclare(QueueNameEft, true, false, false, null);
            //_channel.QueueBind(exchange: ExchangeName, queue: QueueNameEft, routingKey: Routing);

            //_logger.LogInformation("RabbitMQ ile bağlantı kuruldu...");

            return _channel;
        }


        public void Dispose()
        {
            _channel?.Close();
            _channel?.Dispose();

            _connection?.Close();
            _connection?.Dispose();

            //_logger.LogInformation("RabbitMQ ile bağlantı koptu...");
        }
    }
}
