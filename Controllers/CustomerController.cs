using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using auth_jwt_refresh_mechanism.Dtos;
using auth_jwt_refresh_mechanism.Helpers;
using auth_jwt_refresh_mechanism.Interfaces;
using auth_jwt_refresh_mechanism.Interfaces.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace auth_jwt_refresh_mechanism.Controllers
{
    [Authorize]
    //[DisableCors]
   // [EnableRateLimiting("fixedwindow")]
    [Route("/api/customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepo _customerRepo;

        public CustomerController(ICustomerRepo customerRepo)
        {
            _customerRepo = customerRepo;
        }


          //[AllowAnonymous]
       // [EnableCors("corspolicy1")]
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll(){
             if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var customers = await _customerRepo.GetAll();
            if(customers == null){
                return NotFound("Customers not found");
            }
            return Ok(customers);
        }

        [DisableRateLimiting]

        [HttpGet("Getbycode")]
        public async Task<IActionResult> GetByCode(string code){
            // http://localhost:5000/api/controllername/Getbycode/12345
            // http://localhost:5000/api/controllername/Getbycode?queryCode=12345
            
            if (string.IsNullOrEmpty(code))
            {
                return BadRequest("Code parameter is required.");
            }

            var data = await _customerRepo.GetByCode(code);
            if (data == null)
            {
                return NotFound();
            }

            return Ok(data);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(Customermodal _data){
            var data = await _customerRepo.Create(_data);
            return Ok(data);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update(Customermodal _data, string code){
            var data = await _customerRepo.Update(_data,code);
            return Ok(data);
        }

        [HttpDelete("Remove")]
        public async Task<IActionResult> Remove(string code)
        {
            var data = await _customerRepo.Remove(code);
            return Ok(data);
        }
    }
}