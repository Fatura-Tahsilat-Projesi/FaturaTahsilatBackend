using MicrosoftOrnekBackendUyg.Core.Repositories;
using MicrosoftOrnekBackendUyg.Core.UnitOfWorks;
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

        //private ProductRepository _productRepository;

        public IProductRepository Products => throw new NotImplementedException();

        public ICategoryRepository Categories => throw new NotImplementedException();

        public UnitOfWork(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
