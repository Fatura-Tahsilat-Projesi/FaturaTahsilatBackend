using MicrosoftOrnekBackendUyg.Core.Models;
using MicrosoftOrnekBackendUyg.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftOrnekBackendUyg.Core.Repositories
{
    public interface ICreditCardsRepository:IRepository<CreditCards>
    {
        Task<CreditCards> GetAllUserCreditCardAsync(string userId);
    }
}
