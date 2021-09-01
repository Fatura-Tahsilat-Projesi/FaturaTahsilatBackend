using Microsoft.EntityFrameworkCore;
using MicrosoftOrnekBackendUyg.Core.Models;
using MicrosoftOrnekBackendUyg.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftOrnekBackendUyg.Data.Repositories
{
    public class InvoiceRepository : Repository<Invoice>, IInvoiceRepository
    {
        //private AppDbContext appDbContext { get => _context as AppDbContext; }
        private AppDbContext _appDbContext { get => _context as AppDbContext; }
        public InvoiceRepository(AppDbContext context) : base(context)
        {
        }

        //public Task<Invoice> faturaHareketKayitAsync(int InvoiceId)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<Invoice> GetWithInvoiceActivitiesByIdAsync(int InvoiceId)
        {
            return await _appDbContext.Invoices.Include(x => x.InvoiceActivities).SingleOrDefaultAsync(x => x.InvoiceId == InvoiceId);
            //return await appDbContext.Invoices.Include(x => x.InvoiceActivities).SingleOrDefaultAsync(x => x.InvoiceId == InvoiceId);
        }

    }
}
