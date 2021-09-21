using Microsoft.Extensions.Hosting;
using MicrosoftOrnekBackendUyg.Core.Models;
using MicrosoftOrnekBackendUyg.Core.Services;
using MicrosoftOrnekBackendUyg.Core.UnitOfWorks;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace MicrosoftOrnekBackendUyg.RabbitMQ
{
    public class OnlinePaymentProcessBackgroundService : BackgroundService
    {
        private readonly RabbitMQClientService _rabbitMQClientService;
        private IModel _channel;
        //private readonly IService<OnlinePaymentEvent> _service;
        //private readonly IService<User> _userService;
        //private readonly IService<Invoşce>
        //private readonly ILogger<OnlinePaymentProcessBackgroundService> _logger;
        //protected readonly DbContext _context;
        private IPaymentService _paymentService;
        public OnlinePaymentProcessBackgroundService(RabbitMQClientService rabbitMQClientService, IPaymentService paymentService)
        {
            _rabbitMQClientService = rabbitMQClientService;
            _paymentService = paymentService;
            //_context = context;
            // _service = service;
            //_userService = userService;
            //_logger = logger;

        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            _channel = _rabbitMQClientService.Connect();

            _channel.BasicQos(0, 1, false);

            return base.StartAsync(cancellationToken);
        }
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consumer = new AsyncEventingBasicConsumer(_channel);

            _channel.BasicConsume(RabbitMQClientService.QueueName, false, consumer);

            consumer.Received += Consumer_Received;

            return Task.CompletedTask;
        }

        private Task Consumer_Received(object sender, BasicDeliverEventArgs @event)
        {
            Task.Delay(10000).Wait();
            /*try
            {*/
            var creditCards = JsonSerializer.Deserialize<OnlinePaymentEvent>(Encoding.UTF8.GetString(@event.Body.ToArray()));
            //balance(bakiye) kontrolü
            //var userInformation = _userService.GetByIdAsync(creditCards.UserId);
            //var userInformation = _invoiceService.GetByIdAsync(creditCards.UserId);
            //var userInformation = _invoiceService.PaymentUpdate(creditCards.InvoiceId);
            _paymentService.PaymentUpdate(creditCards.InvoiceId);


            //var balance = userInformation;
            //Debug.Print($"Gelen userInformation = {userInformation}");
            Invoice guncellenecekFatura = new Invoice { InvoiceId = creditCards.InvoiceId, StatusCode = 1, IsComplete = 1};
            //_context.Entry(guncellenecekFatura).State = EntityState.Modified;


            if (creditCards.UserId == 1)
            {
                //_service.Update(creditCards);
            }





            //_logger.LogInformation("Nesne Çıktısı => " + creditCards);
            //Debug.Print(creditCards.ToString());
            //Debug.Print($"Gelen Mesaj = {creditCards.InvoiceId}");
            //Dispose();
            _channel.BasicAck(@event.DeliveryTag, false);
            /*}
            catch (Exception ex)
            {

                throw;
            }*/
            return Task.CompletedTask;
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            return base.StopAsync(cancellationToken);
        }
    }
}
