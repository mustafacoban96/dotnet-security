using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using auth_jwt_refresh_mechanism.Interfaces;
using auth_jwt_refresh_mechanism.Model;
using auth_jwt_refresh_mechanism.Repository;
using Microsoft.EntityFrameworkCore;

namespace auth_jwt_refresh_mechanism.service
{
    public class RefreshHandler : IRefreshHandler
    {
        private readonly ApplicationDbContext _context;

        public RefreshHandler(ApplicationDbContext context){
            _context = context;

        }
        public async Task<string> GenerateToken(string username)
        {
            var randomnumber = new byte[32];
            using(var randomnumbergenerator= RandomNumberGenerator.Create())
            {
                randomnumbergenerator.GetBytes(randomnumber);
                string refreshtoken=Convert.ToBase64String(randomnumber);
                var Existtoken = _context.TblRefreshtokens.FirstOrDefaultAsync(item=>item.Userid==username).Result;
                if (Existtoken != null)
                {
                    Existtoken.Refreshtoken = refreshtoken;
                }
                else
                {
                   await _context.TblRefreshtokens.AddAsync(new TblRefreshtoken
                    {
                       Userid=username,
                       Tokenid= new Random().Next().ToString(),
                       Refreshtoken=refreshtoken
                   });
                }
                await _context.SaveChangesAsync();

                return refreshtoken;

            }
        }
    }
}