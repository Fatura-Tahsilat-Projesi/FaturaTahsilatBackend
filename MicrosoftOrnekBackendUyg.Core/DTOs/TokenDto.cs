using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftOrnekBackendUyg.Core.DTOs
{
    public class TokenDto
    {
        public string UserIdValue { get; set; }
        public string AccessToken { get; set; }

        public DateTime AccessTokenExpiration { get; set; }

        public string RefreshToken { get; set; }

        public DateTime RefreshTokenExpiration { get; set; }
    }
}
