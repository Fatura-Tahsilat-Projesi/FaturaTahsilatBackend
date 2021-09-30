using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MicrosoftOrnekBackendUyg.Core.Models;
using MicrosoftOrnekBackendUyg.Core.Services;
using MicrosoftOrnekBackendUyg.DTOs;
using MicrosoftOrnekBackendUyg.RabbitMQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicrosoftOrnekBackendUyg.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class InvoicesController : ControllerBase
    {
        //private readonly IService<Invoice> _invoiceService;
        private readonly IInvoiceService _invoiceService;
        private readonly IMapper _mapper;
        private readonly RabbitMQPublisher _rabbitMQPublisher;

        //private readonly ILogger<InvoicesController> _logger;

        public InvoicesController(IInvoiceService invoiceService, IMapper mapper, RabbitMQPublisher rabbitMQPublisher)
        {
            _invoiceService = invoiceService;
            _mapper = mapper;
            //_logger = logger;
            _rabbitMQPublisher = rabbitMQPublisher;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //_rabbitMQPublisher.Publish(new CreditCards() { Id = 1, Balance = 250, UserId = 1, CardNumber = "1111", CreditCardType = 1, CVC2 = 123, ExpMonth = 9, ExpYear = 3, CreatedAt = DateTime.ParseExact("01/09/2021 10:05:00", "dd/MM/yyyy HH:mm:ss", null) });
            //test amaçlı bağlantı yapıldı.
            var invoices = await _invoiceService.GetAllAsync();
            Serilog.Log.Information("Tüm faturalar çağırıldı.");
            return Ok(_mapper.Map<IEnumerable<InvoiceDto>>(invoices));
        }

        [HttpGet("{userId}/allinvoices")]
        public async Task<IActionResult> GetAllUserInvoices(string userId)
        {
            var invoices = await _invoiceService.Where(x => x.UserId == userId);
            return Ok(invoices);
            //return Ok(_mapper.Map<IEnumerable<InvoiceDto>>(invoices));
        }

        [HttpGet("{companyId}/companyallinvoices")]
        public async Task<IActionResult> GetAllCompanyInvoices(int companyId)
        {
            var invoices = await _invoiceService.Where(x => x.CompanyId == companyId);
            return Ok(invoices);
            //return Ok(_mapper.Map<IEnumerable<InvoiceDto>>(invoices));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var invoice = await _invoiceService.GetByIdAsync(id);
            // Serilog.Log.Information(id + " numaralı fatura çağırıldı.);
            Serilog.Log.Information(id + " numaralı fatura çağırıldı. Bilgiler => | FaturaNu: " + invoice.InvoiceNu + " | FaturaIsim: " + invoice.Name + " | FaturaToplam: " + invoice.Total + " | FaturaToplamKDV: " + invoice.TotalVat + " | FaturaKDVsiz: " + invoice.ExcludingVat + " | SonOdemeTarihi: " + invoice.DueDate + " | FaturaTipi: " + invoice.InvoiceType + " | DurumKodu: " + invoice.StatusCode + " | OdenmeDurumu: " + invoice.IsComplete + " | FirmaId: " + invoice.CompanyId + " | UserId: " + invoice.UserId + " | ");
            return Ok(_mapper.Map<InvoiceDto>(invoice));
        }

        [HttpGet("{id}/invoiceActivities")]
        public async Task<IActionResult> GetWithInvoiceActivitiesByIdAsync(int id)
        {
            var invoiceActivities = await _invoiceService.GetWithInvoiceActivitiesByIdAsync(id);
            Serilog.Log.Information("Faturaya bağlı fatura hareketi çağırıldı. Bilgiler => | FaturaId: " + invoiceActivities.InvoiceId + " | SonOdemeTarihi: " + invoiceActivities.DueDate + " | DurumKodu: " + invoiceActivities.StatusCode + " | FirmaId: " + invoiceActivities.CompanyId + " | UserId: " + invoiceActivities.UserId + " | ");
            return Ok(invoiceActivities);
        }

        [HttpPost]
        public async Task<IActionResult> Save(Invoice invoice)
        {
            var newInvoices = await _invoiceService.AddAsync(invoice);
            Serilog.Log.Information("Fatura  Eklendi. Bilgiler => | FaturaNu: " + invoice.InvoiceNu + " | FaturaIsim: " + invoice.Name + " | FaturaToplam: " + invoice.Total + " | FaturaToplamKDV: " + invoice.TotalVat + " | FaturaKDVsiz: " + invoice.ExcludingVat + " | SonOdemeTarihi: " + invoice.DueDate + " | FaturaTipi: " + invoice.InvoiceType + " | DurumKodu: " + invoice.StatusCode + " | OdenmeDurumu: " + invoice.IsComplete + " | FirmaId: " + invoice.CompanyId + " | UserId: " + invoice.UserId + " | ");
            return Ok(newInvoices);
        }


        [HttpPut]
        public IActionResult Update(Invoice invoice)
        {
            //_logger.LogInformation("Fatura Güncelleme fonk.invoice => "+invoice);
            //_rabbitMQPublisher.Publish(new CreditCards() { Id = 1, Balance = 250, UserId = invoice.UserId, CardNumber = "1111", CreditCardType = 1, CVC2 = 123, ExpMonth = 9, ExpYear = 3, CreatedAt = DateTime.ParseExact("01/09/2021 10:05:00", "dd/MM/yyyy HH:mm:ss", null) });
            
            //--var updateInvoice = _invoiceService.Update(invoice);
            _rabbitMQPublisher.Publish(new OnlinePaymentEvent() { InvoiceId = invoice.InvoiceId });
            Serilog.Log.Information("Fatura  Güncellendi. Bilgiler => | FaturaNu: " + invoice.InvoiceNu + " | FaturaIsim: " + invoice.Name + " | FaturaToplam: " + invoice.Total + " | FaturaToplamKDV: " + invoice.TotalVat + " | FaturaKDVsiz: " + invoice.ExcludingVat + " | SonOdemeTarihi: " + invoice.DueDate + " | FaturaTipi: " + invoice.InvoiceType + " | DurumKodu: " + invoice.StatusCode + " | OdenmeDurumu: " + invoice.IsComplete + " | FirmaId: " + invoice.CompanyId + " | UserId: " + invoice.UserId + " | ");
            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var invoices = _invoiceService.GetByIdAsync(id).Result;

            _invoiceService.Remove(invoices);
            Serilog.Log.Information("Fatura  Silindi. Bilgiler => | FaturaNu: " + invoices.InvoiceNu + " | FaturaIsim: " + invoices.Name + " | FaturaToplam: " + invoices.Total + " | FaturaToplamKDV: " + invoices.TotalVat + " | FaturaKDVsiz: " + invoices.ExcludingVat + " | SonOdemeTarihi:  " + invoices.DueDate + " | FaturaTipi: " + invoices.InvoiceType + " | DurumKodu: " + invoices.StatusCode + " | OdenmeDurumu: " + invoices.IsComplete + " | FirmaId: " + invoices.CompanyId + " | UserId: " + invoices.UserId + " | ");
            return NoContent();
        }




    }
}
