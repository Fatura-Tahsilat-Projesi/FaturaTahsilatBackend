using MicrosoftOrnekBackendUyg.Core.Repositories;
using MicrosoftOrnekBackendUyg.Core.UnitOfWorks;
using MicrosoftOrnekBackendUyg.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftOrnekBackendUyg.Data.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        private InvoiceRepository _invoiceRepository;
        private InvoiceActivityRepository _invoiceActivityRepository;
        private UserRepository _userRepository;
        private CreditCardsRepository _creditCardsRepository;

        public IInvoiceRepository Invoices => _invoiceRepository = _invoiceRepository ?? new InvoiceRepository(_context);

        public IInvoiceActivityRepository InvoiceActivities => _invoiceActivityRepository = _invoiceActivityRepository ?? new InvoiceActivityRepository(_context);

        public IUserRepository UserRepository => _userRepository = _userRepository ?? new UserRepository(_context);

        public ICreditCardsRepository CreditCardsRepository => _creditCardsRepository = _creditCardsRepository ?? new CreditCardsRepository(_context);

        //public ICategoryRepository Categories => throw ;

        public UnitOfWork(AppDbContext appDbContext)
        {
            _context = appDbContext;
            
        }

        //public IProductRepository Products => throw new NotImplementedException();

        //public ICategoryRepository Categories => throw new NotImplementedException();

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void LogCiktiBas()
        {

            //_logger.LogDebug("Çıktı!");
        }


    }
}
