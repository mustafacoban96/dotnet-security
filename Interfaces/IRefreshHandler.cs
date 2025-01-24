using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace auth_jwt_refresh_mechanism.Interfaces
{
    public interface IRefreshHandler
    {
        Task<string> GenerateToken(string username);
    }
}