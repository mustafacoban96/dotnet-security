using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace auth_jwt_refresh_mechanism.Helpers
{
    public class APIResponse
    {
        public int ResponseCode { get; set; }
        public string Result { get; set; }
        public string Message { get; set; }
    }
}