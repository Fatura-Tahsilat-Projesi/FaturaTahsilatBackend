using MicrosoftOrnekBackendUyg.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftOrnekBackendUyg.Core.UnitOfWorks
{
    public interface IUnitOfWork
    {
        IInvoiceRepository Invoices { get; }

        IInvoiceActivityRepository InvoiceActivities { get; }

        Task CommitAsync();

        void Commit();


    }
}
