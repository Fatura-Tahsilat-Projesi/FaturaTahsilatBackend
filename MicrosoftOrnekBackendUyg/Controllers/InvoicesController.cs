using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MicrosoftOrnekBackendUyg.Core.Models;
using MicrosoftOrnekBackendUyg.Core.Services;
using MicrosoftOrnekBackendUyg.DTOs;
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

        public InvoicesController(IInvoiceService invoiceService, IMapper mapper)
        {
            _invoiceService = invoiceService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var invoices = await _invoiceService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<InvoiceDto>>(invoices));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var invoice = await _invoiceService.GetByIdAsync(id);

            return Ok(_mapper.Map<InvoiceDto>(invoice));
        }

        [HttpGet("{id}/invoiceActivities")]
        public async Task<IActionResult> GetWithInvoiceActivitiesByIdAsync(int id)
        {
            var invoiceActivities = await _invoiceService.GetWithInvoiceActivitiesByIdAsync(id);

            return Ok(invoiceActivities);
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
