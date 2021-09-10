using MicrosoftOrnekBackendUyg.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftOrnekBackendUyg.Core.Repositories
{
    public interface IUserRepository:IRepository<User>
    {
        Task<User> GetWithInvoiceByIdAsync(int UserId);
        Task<User> Authenticate(int id);
        string CreateTokenAsync(TokenDescriptor descriptor);
    }
}
