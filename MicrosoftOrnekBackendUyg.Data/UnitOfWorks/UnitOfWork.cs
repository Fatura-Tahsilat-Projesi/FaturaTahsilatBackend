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

        private ProductRepository _productRepository;
        private CategoryRepository _categoryRepository;

        public IProductRepository Products => _productRepository = _productRepository ?? new ProductRepository(_context);

        public ICategoryRepository Categories => _categoryRepository = _categoryRepository ?? new CategoryRepository(_context);

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
    }
}
