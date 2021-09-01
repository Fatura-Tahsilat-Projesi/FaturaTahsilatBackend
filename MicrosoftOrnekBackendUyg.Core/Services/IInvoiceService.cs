using MicrosoftOrnekBackendUyg.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftOrnekBackendUyg.Core.Services
{
    public interface IInvoiceService:IService<Invoice>
    {
        Task<Invoice> GetWithInvoiceActivitiesByIdAsync(int InvoiceId);
    }
}
