using Microsoft.Extensions.Logging;
using MicrosoftOrnekBackendUyg.Core.Models;
using MicrosoftOrnekBackendUyg.Core.Repositories;
using MicrosoftOrnekBackendUyg.Core.Services;
using MicrosoftOrnekBackendUyg.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftOrnekBackendUyg.Service.Services
{
    public class CreditCardsService : Service<CreditCards>, ICreditCardsService
    {
        public CreditCardsService(IUnitOfWork unitOfWork, IRepository<CreditCards> repository, ILogger<CreditCards> logger) : base(unitOfWork,repository, logger)
        {
        }

        public async Task<CreditCards> GetAllUserCreditCardAsync(string userId)
        {
            return await _unitOfWork.CreditCardsRepository.GetAllUserCreditCardAsync(userId);

            //throw new NotImplementedException();
        }
    }
}
