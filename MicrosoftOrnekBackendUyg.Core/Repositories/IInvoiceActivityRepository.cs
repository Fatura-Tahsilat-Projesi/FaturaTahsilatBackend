using MicrosoftOrnekBackendUyg.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftOrnekBackendUyg.Core.Repositories
{
    public interface IInvoiceActivityRepository:IRepository<InvoiceActivity>
    {
        Task<InvoiceActivity> GetWithInvoiceActivityByIdAsync(int InvoiceActivityId);
    }
}
