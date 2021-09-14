using Microsoft.Extensions.Logging;
using MicrosoftOrnekBackendUyg.Core.Models;
using MicrosoftOrnekBackendUyg.Core.Repositories;
using MicrosoftOrnekBackendUyg.Core.Services;
using MicrosoftOrnekBackendUyg.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftOrnekBackendUyg.Service.Services
{
    public class InvoiceService : Service<Invoice>, IInvoiceService
    {
        public InvoiceService(IUnitOfWork unitOfWork, IRepository<Invoice> repository, ILogger<Invoice> logger) : base(unitOfWork, repository, logger)
        {
        }

        public async Task<Invoice> GetWithInvoiceActivitiesByIdAsync(int InvoiceId)
        {
           return await _unitOfWork.Invoices.GetWithInvoiceActivitiesByIdAsync(InvoiceId);
        }
    }
}
