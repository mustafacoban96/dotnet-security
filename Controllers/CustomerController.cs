using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using auth_jwt_refresh_mechanism.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace auth_jwt_refresh_mechanism.Controllers
{
    [Route("api/customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }


        [HttpGet('/getAll')]
        public async  Task<IActionResult> getAllCustomer(){
            return Ok("Creeewqeq");
        }
    }
}