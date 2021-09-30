﻿using MicrosoftOrnekBackendUyg.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftOrnekBackendUyg.Core.Repositories
{
    public interface IUserRepository:IRepository<CustomUser>
    {
        Task<CustomUser> GetWithInvoiceByIdAsync(int UserId);
        Task<CustomUser> Authenticate(int id);
        string CreateTokenAsync(TokenDescriptor descriptor);
    }
}
