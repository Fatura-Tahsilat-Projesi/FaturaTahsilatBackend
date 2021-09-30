using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftOrnekBackendUyg.Core.DTOs
{
    public class RoleDto: IdentityRole
    {
        public string CustomName { get; set; }
    }
}
