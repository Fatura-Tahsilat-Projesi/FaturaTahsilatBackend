using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MicrosoftOrnekBackendUyg.Core.Models;
using MicrosoftOrnekBackendUyg.Core.Services;
using MicrosoftOrnekBackendUyg.Core.UnitOfWorks;
using MicrosoftOrnekBackendUyg.Data;
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
        //IUnitOfWork _unitOfWork;
        //private readonly IService<OnlinePaymentEvent> _service;
        //private readonly IService<User> _userService;
        //private readonly IService<Invoşce>
        //private readonly ILogger<OnlinePaymentProcessBackgroundService> _logger;
        //protected readonly DbContext _context;
        private IPaymentService _paymentService;
        public IServiceScopeFactory _serviceScopeFactory;
        private ValueTask<Invoice> guncellenecekFaturaDegeri;

        public OnlinePaymentProcessBackgroundService(RabbitMQClientService rabbitMQClientService, IPaymentService paymentService, IServiceScopeFactory serviceScopeFactory)
        {
            _rabbitMQClientService = rabbitMQClientService;
            _paymentService = paymentService;
            //_unitOfWork = unitOfWork;
            //_context = context;
            // _service = service;
            //_userService = userService;
            //_logger = logger;
            _serviceScopeFactory = serviceScopeFactory;
           

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

            var creditCards = JsonSerializer.Deserialize<OnlinePaymentEvent>(Encoding.UTF8.GetString(@event.Body.ToArray()));
           
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                
                guncellenecekFaturaDegeri = dbContext.Invoices.FindAsync(creditCards.InvoiceId);
                guncellenecekFaturaDegeri.Result.IsComplete = 1;
                guncellenecekFaturaDegeri.Result.StatusCode = 1;

                dbContext.Invoices.Update(guncellenecekFaturaDegeri.Result);
                var dbProcess = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
                dbProcess.Commit();
                Serilog.Log.Information("Fatura Ödemesi yapıldı. Bilgiler => | user: " + creditCards.UserId + " | fatura: " + creditCards.InvoiceId);
                var date = DateTime.Now.ToString();
                var invoiceActivity = new InvoiceActivity() { InvoiceId = creditCards.InvoiceId, UserId = creditCards.UserId, TransactionDate = DateTime.ParseExact(date, "d/MM/yyyy HH:mm:ss", null), StatusCode = 1, CompanyId = 1 };
                dbContext.InvoiceActivities.AddAsync(invoiceActivity);
                dbProcess.Commit();

            }

            _channel.BasicAck(@event.DeliveryTag, false);
            
            return Task.CompletedTask;
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            return base.StopAsync(cancellationToken);
        }
    }
}
