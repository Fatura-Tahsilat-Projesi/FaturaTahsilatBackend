
using MicrosoftOrnekBackendUyg.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftOrnekBackendUyg.Core.Services
{
    public interface IUserService:IService<User>
    {
        Task<User> Authenticate(int id);
        string CreateTokenAsync(TokenDescriptor descriptor);
        //public Task<User> ValidateUserAsync(User request);
    }
}
