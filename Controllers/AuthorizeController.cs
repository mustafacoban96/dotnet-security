using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using auth_jwt_refresh_mechanism.Dtos;
using auth_jwt_refresh_mechanism.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace auth_jwt_refresh_mechanism.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthorizeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AuthorizeController(ApplicationDbContext context){
            _context = context;
        }

        [HttpPost("GenerateToken")]
        public async Task<IActionResult> GenerateToken([FromBody] UserCred userCred){
            var user =await _context.TblUsers.FirstOrDefaultAsync(item => item.Username == userCred.username && item.Password == userCred.username);

            if(user != null){
                // generate token
            }
            else{
                return Unauthorized();
            }


            return Ok("");
            
        }

    }
}