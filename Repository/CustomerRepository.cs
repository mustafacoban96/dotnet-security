using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using auth_jwt_refresh_mechanism.Dtos;
using auth_jwt_refresh_mechanism.Interfaces.IRepository;
using auth_jwt_refresh_mechanism.Mapper;
using auth_jwt_refresh_mechanism.Model;
using Microsoft.EntityFrameworkCore;

namespace auth_jwt_refresh_mechanism.Repository
{
    public class CustomerRepository : ICustomerRepo
    {
        private readonly ApplicationDbContext _context;

        public CustomerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

         public async Task<List<CustomerDto>> GetAll()
        {
            var customers = await _context.TblCustomers.ToListAsync();
            var customersDto = customers.Select(c => c.ToCustomerModal()).ToList();
            return customersDto;
            
        }
    }
}