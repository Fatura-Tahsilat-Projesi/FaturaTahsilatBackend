using MicrosoftOrnekBackendUyg.Core.Models;
using MicrosoftOrnekBackendUyg.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftOrnekBackendUyg.Data.Repositories
{
    class InvoiceActivityRepository: Repository<InvoiceActivity>, IInvoiceActivityRepository
    {
        public InvoiceActivityRepository(AppDbContext context) : base(context)
        {
        }

        private AppDbContext appDbContext { get => _context as AppDbContext; }

        public Task<InvoiceActivity> GetWithInvoiceActivityByIdAsync(int InvoiceActivityId)
        {
            throw new NotImplementedException();
        }
    }
}
