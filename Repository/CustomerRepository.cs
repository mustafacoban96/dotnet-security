using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using auth_jwt_refresh_mechanism.Dtos;
using auth_jwt_refresh_mechanism.Interfaces.IRepository;
using auth_jwt_refresh_mechanism.Mapper;
using auth_jwt_refresh_mechanism.Model;
using AutoMapper;
using Azure;
using Microsoft.EntityFrameworkCore;

namespace auth_jwt_refresh_mechanism.Repository
{
    public class CustomerRepository : ICustomerRepo
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CustomerRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

         public async Task<List<Customermodal>> GetAll()
        {
            // var customers = await _context.TblCustomers.ToListAsync();
            // var customersDto = customers.Select(c => c.ToCustomerModal()).ToList();
            // return customersDto;

            List<Customermodal> _response=new List<Customermodal>();
            var _data = await _context.TblCustomers.ToListAsync();
            if(_data != null )
            {
                _response=_mapper.Map<List<TblCustomer>,List<Customermodal>>(_data);
            }
            return _response;

            
        }
    }
}