using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MicrosoftOrnekBackendUyg.Core.Models;
using MicrosoftOrnekBackendUyg.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicrosoftOrnekBackendUyg.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceActivitiesController : ControllerBase
    {
        private readonly IService<InvoiceActivity> _invoiceActivityService;

        public InvoiceActivitiesController(IService<InvoiceActivity> invoiceActivityService)
        {
            _invoiceActivityService = invoiceActivityService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var invoiceActivities = await _invoiceActivityService.GetAllAsync();
            Serilog.Log.Information("Tüm fatura hareketleri çağırıldı.");
            return Ok(invoiceActivities);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var invoiceActivitiy = await _invoiceActivityService.GetByIdAsync(id);
            Serilog.Log.Information(id + " numaralı fatura hareketi çağırıldı. Bilgiler => | FaturaId: " + invoiceActivitiy.InvoiceId + " | SonOdemeTarihi: " + invoiceActivitiy.TransactionDate + " | DurumKodu: " + invoiceActivitiy.StatusCode + " | FirmaId: " + invoiceActivitiy.CompanyId + " | UserId: " + invoiceActivitiy.UserId + " | ");
            return Ok(invoiceActivitiy);
        }



        [HttpPost]
        public async Task<IActionResult> Save(InvoiceActivity invoiceActivity)
        {
            var newInvoiceActivities = await _invoiceActivityService.AddAsync(invoiceActivity);
            Serilog.Log.Information("Fatura hareketi kaydedildi. Bilgiler => | FaturaId: " + newInvoiceActivities.InvoiceId + " | SonOdemeTarihi: " + newInvoiceActivities.TransactionDate + " | DurumKodu: " + newInvoiceActivities.StatusCode + " | FirmaId: " + newInvoiceActivities.CompanyId + " | UserId: " + newInvoiceActivities.UserId + " | ");
            return Ok(newInvoiceActivities);
        }

        [HttpPut]
        public IActionResult Update(InvoiceActivity invoiceActivity)
        {
            var updateInvoice = _invoiceActivityService.Update(invoiceActivity);
            Serilog.Log.Information("Fatura hareketi güncellendi. Bilgiler => | FaturaId: " + updateInvoice.InvoiceId + " | SonOdemeTarihi: " + updateInvoice.TransactionDate + " | DurumKodu: " + updateInvoice.StatusCode + " | FirmaId: " + updateInvoice.CompanyId + " | UserId: " + updateInvoice.UserId + " | ");
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var invoiceActivities = _invoiceActivityService.GetByIdAsync(id).Result;

            _invoiceActivityService.Remove(invoiceActivities);
            Serilog.Log.Information("Fatura hareketi güncellendi. Bilgiler => | FaturaId: " + invoiceActivities.InvoiceId + " | SonOdemeTarihi: " + invoiceActivities.TransactionDate + " | DurumKodu: " + invoiceActivities.StatusCode + " | FirmaId: " + invoiceActivities.CompanyId + " | UserId: " + invoiceActivities.UserId + " | ");
            return NoContent();
        }



    }
}
