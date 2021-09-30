using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftOrnekBackendUyg.Core.Models
{
    public class UserApp : IdentityUser
    {
        public string City { get; set; }

        public virtual Invoice Invoice { get; set; }

        public virtual Company Company { get; set; }
        public virtual Log Log { get; set; }

    }
}
