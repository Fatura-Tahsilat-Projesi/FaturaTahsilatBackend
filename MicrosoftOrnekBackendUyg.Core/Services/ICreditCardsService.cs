using MicrosoftOrnekBackendUyg.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftOrnekBackendUyg.Core.Services
{
    public interface ICreditCardsService: IService<CreditCards>
    {
        Task<CreditCards> GetAllUserCreditCardAsync(string userId);

    }
}
