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
    public class InvoiceActivityService : Service<InvoiceActivity>, IInvoiceActivityService
    {
        public InvoiceActivityService(IUnitOfWork unitOfWork, IRepository<InvoiceActivity> repository, ILogger<InvoiceActivity> logger ) : base(unitOfWork, repository, logger)
        {
        }
    }
}
