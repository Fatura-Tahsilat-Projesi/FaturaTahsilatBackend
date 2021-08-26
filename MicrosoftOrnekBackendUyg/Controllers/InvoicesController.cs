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
    [Route("api/[controller]")]
    [ApiController]
    public class InvoicesController : ControllerBase
    {
        private readonly IService<Invoice> _invoiceService;

        public InvoicesController(IService<Invoice> invoiceService)
        {
            _invoiceService = invoiceService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var invoices = await _invoiceService.GetAllAsync();
            return Ok(invoices);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var invoice = await _invoiceService.GetByIdAsync(id);

            return Ok(invoice);
        }


        [HttpPost]
        public async Task<IActionResult> Save(Invoice invoice)
        {
            var newInvoices = await _invoiceService.AddAsync(invoice);
            return Ok(newInvoices);
        }


        [HttpPut]
        public IActionResult Update(Invoice invoice)
        {
            var updateInvoice = _invoiceService.Update(invoice);

            return NoContent();
        }



        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var invoices = _invoiceService.GetByIdAsync(id).Result;

            _invoiceService.Remove(invoices);
            return NoContent();
        }




    }
}
