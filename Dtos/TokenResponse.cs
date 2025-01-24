using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace auth_jwt_refresh_mechanism.Dtos
{
    public class TokenResponse
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public string UserRole { get; set; }
    }
}