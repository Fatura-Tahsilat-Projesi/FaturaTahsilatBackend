using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MicrosoftOrnekBackendUyg.Core.Models;
using MicrosoftOrnekBackendUyg.Core.Repositories;
using MicrosoftOrnekBackendUyg.Data.Repositories;
using MicrosoftOrnekBackendUyg.Data;

namespace MicrosoftOrnekBackendUyg.Data.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private AppDbContext appDbContext { get => _context as AppDbContext; }

        public ProductRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Product> GetWithCategoryByIdAsync(int productId)
        {
            return await appDbContext.Products.Include(x => x.Category).SingleOrDefaultAsync(x => x.Id == productId);
        }
    }
}