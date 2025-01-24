using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using auth_jwt_refresh_mechanism.Dtos;
using auth_jwt_refresh_mechanism.Interfaces;
using auth_jwt_refresh_mechanism.Repository;
using auth_jwt_refresh_mechanism.service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;

namespace auth_jwt_refresh_mechanism.Controllers
{
    [ApiController]
    [Route("api/auth/")]
    public class AuthorizeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly TokenService _tokenservice;
        //private readonly IRefreshHandler _refresh;

        public AuthorizeController(ApplicationDbContext context,IOptions<TokenService> options){
            _context = context;
            _tokenservice = options.Value;
            //_refresh = refresh;
            

        }

        [HttpPost("GenerateToken")]
        public async Task<IActionResult> GenerateToken([FromBody] UserCred userCred){
            var user =await _context.TblUsers.FirstOrDefaultAsync(item => item.Username == userCred.username && item.Password == userCred.password);

            if(user != null){
                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenKey = Encoding.UTF8.GetBytes(_tokenservice._key);
                var tokendesc = new SecurityTokenDescriptor{
                    Subject = new ClaimsIdentity(new Claim[]{
                        new Claim(ClaimTypes.Name, user.Username),
                        new Claim(ClaimTypes.Role,user.Role)
                    }),
                    Expires=DateTime.UtcNow.AddSeconds(3000),
                    SigningCredentials=new SigningCredentials(new SymmetricSecurityKey(tokenKey),SecurityAlgorithms.HmacSha256) 
                };
                var token = tokenHandler.CreateToken(tokendesc);
                var finalToken = tokenHandler.WriteToken(token);
                return Ok(finalToken);
               
                // return Ok(new TokenResponse() {
                //     Token = finalToken,
                //     RefreshToken = await _refresh.GenerateToken(userCred.username),UserRole=user.Role
                // });
                
            }
            else{
                return Unauthorized();
            }
            
        }

        // [HttpPost("GenerateRefreshToken")]
        // public async Task<IActionResult> GenerateToken([FromBody] TokenResponse token){
        //     var _refreshtoken = await _context.TblRefreshtokens.FirstOrDefaultAsync(item => item.Refreshtoken == token.RefreshToken);
        //     if (_refreshtoken != null){
        //          var tokenhandler = new JwtSecurityTokenHandler();
        //         var tokenkey = Encoding.UTF8.GetBytes(_tokenservice._key);
        //         SecurityToken securityToken;
        //         var principal = tokenhandler.ValidateToken(token.Token, new TokenValidationParameters()
        //         {
        //             ValidateIssuerSigningKey = true,
        //             IssuerSigningKey = new SymmetricSecurityKey(tokenkey),
        //             ValidateIssuer = false,
        //             ValidateAudience = false,

        //         }, out securityToken);

        //         var _token = securityToken as JwtSecurityToken;
        //         if(_token != null && _token.Header.Alg.Equals(SecurityAlgorithms.HmacSha256)){
        //             string username = principal.Identity?.Name;
        //             var _existdata = await _context.TblRefreshtokens.FirstOrDefaultAsync(item => item.Userid==username && item.Refreshtoken == token.RefreshToken);
        //             if(_existdata != null){
        //                 var _newtoken = new JwtSecurityToken(
        //                     claims:principal.Claims.ToArray(),
        //                     expires:DateTime.Now.AddSeconds(30),
        //                     signingCredentials:new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenservice._key)),
        //                     SecurityAlgorithms.HmacSha256)
        //                 );
        //                 var _finaltoken = tokenhandler.WriteToken(_newtoken);
        //                 return Ok(new TokenResponse() { Token = _finaltoken, RefreshToken = await _refresh.GenerateToken(username),UserRole=token.UserRole });
        //             }
        //             else{
        //                 return Unauthorized();
        //             }
        //         }
        //         else{
        //             return Unauthorized();
        //         }

        // //         //var tokendesc = new SecurityTokenDescriptor
        // //         //{
        // //         //    Subject = new ClaimsIdentity(new Claim[]
        // //         //    {
        // //         //        new Claim(ClaimTypes.Name,user.Code),
        // //         //        new Claim(ClaimTypes.Role,user.Role)
        // //         //    }),
        // //         //    Expires = DateTime.UtcNow.AddSeconds(30),
        // //         //    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenkey), SecurityAlgorithms.HmacSha256)
        // //         //};
        // //         //var token = tokenhandler.CreateToken(tokendesc);
        // //         //var finaltoken = tokenhandler.WriteToken(token);
        // //         //return Ok(new TokenResponse() { Token = finaltoken, RefreshToken = await this.refresh.GenerateToken(userCred.username) });
        //     }
        //     else{
        //         return Unauthorized();
        //     }
        // }

    }
}