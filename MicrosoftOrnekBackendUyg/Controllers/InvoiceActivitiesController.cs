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
            return Ok(invoiceActivities);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var invoiceActivitiy = await _invoiceActivityService.GetByIdAsync(id);

            return Ok(invoiceActivitiy);
        }



        [HttpPost]
        public async Task<IActionResult> Save(InvoiceActivity invoiceActivity)
        {
            var newInvoiceActivities = await _invoiceActivityService.AddAsync(invoiceActivity);
            return Ok(newInvoiceActivities);
        }

        [HttpPut]
        public IActionResult Update(InvoiceActivity invoiceActivity)
        {
            var updateInvoice = _invoiceActivityService.Update(invoiceActivity);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var invoiceActivities = _invoiceActivityService.GetByIdAsync(id).Result;

            _invoiceActivityService.Remove(invoiceActivities);
            return NoContent();
        }



    }
}
