using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MicrosoftOrnekBackendUyg.Core.Models;

namespace MicrosoftOrnekBackendUyg.Core.Services
{
    public interface ICategoryService : IService<Category>
    {
        Task<Category> GetWithProductsByIdAsync(int categoryId);

        //Category özgü methodlarınız varsa burada tanımlayabilirsiniz.
    }
}