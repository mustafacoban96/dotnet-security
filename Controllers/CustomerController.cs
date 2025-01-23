using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using auth_jwt_refresh_mechanism.Interfaces;
using auth_jwt_refresh_mechanism.Interfaces.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace auth_jwt_refresh_mechanism.Controllers
{
    [Route("/api/customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepo _customerRepo;

        public CustomerController(ICustomerRepo customerRepo)
        {
            _customerRepo = customerRepo;
        }


        [HttpGet]
        public async Task<IActionResult> getAll(){
             if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var customers = await _customerRepo.GetAll();
            return Ok(customers);
        }
    }
}