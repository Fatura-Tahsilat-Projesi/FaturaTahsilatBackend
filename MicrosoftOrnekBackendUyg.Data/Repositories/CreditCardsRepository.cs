using Microsoft.EntityFrameworkCore;
using MicrosoftOrnekBackendUyg.Core.Models;
using MicrosoftOrnekBackendUyg.Core.Repositories;
using MicrosoftOrnekBackendUyg.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftOrnekBackendUyg.Data.Repositories
{
    public class CreditCardsRepository : Repository<CreditCards>, ICreditCardsRepository
    {
        private AppDbContext _appDbContext { get => _context as AppDbContext; }

        public CreditCardsRepository(AppDbContext context) : base(context)
        {

        }

        public async Task<CreditCards> GetAllUserCreditCardAsync(string userId)
        {
            //return await _appDbContext.CreditCards.Include(y => y.UserId).Where(x => x.UserId == userId).Select(userId);
            // çalışıyor ama tek değer döndürür bu metot
             return await _appDbContext.CreditCards.SingleOrDefaultAsync(x => x.UserId == userId);
        }


    }
}
