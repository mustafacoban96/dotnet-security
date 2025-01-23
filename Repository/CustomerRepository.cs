using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using auth_jwt_refresh_mechanism.Dtos;
using auth_jwt_refresh_mechanism.Helpers;
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
        private readonly ILogger<CustomerRepository> _logger;

        public CustomerRepository(ApplicationDbContext context, IMapper mapper ,ILogger<CustomerRepository> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<APIResponse> Create(Customermodal data)
        {
            APIResponse response = new APIResponse();

            try
            {
                _logger.LogInformation("Create Begins");
                TblCustomer _customer = _mapper.Map<Customermodal,TblCustomer>(data);
                await _context.TblCustomers.AddAsync(_customer);
                await _context.SaveChangesAsync();
                response.ResponseCode = 201;
                response.Result = "pass";
            }
            catch (Exception ex)
            {
                response.ResponseCode = 400;
                response.Result = ex.Message;
                _logger.LogError(ex.Message,ex);
            }
            return response;
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

        public async Task<Customermodal> GetByCode(string code)
        {   Customermodal _response = new Customermodal();
            var _data = await _context.TblCustomers.FindAsync(code);
            if(_data != null){
                _response = _mapper.Map<TblCustomer,Customermodal>(_data);
            }
            return _response;
        }

        public async Task<APIResponse> Remove(string code)
        {
            APIResponse response = new APIResponse();

            try
            {
                var _customer = await _context.TblCustomers.FindAsync(code);
                if(_customer != null){
                    _context.TblCustomers.Remove(_customer);
                    await _context.SaveChangesAsync();
                    response.ResponseCode = 200;
                    response.Result = "pass";
                }
                else{
                    response.ResponseCode = 404;
                    response.Message = "Data not found";
                }
            }
            catch (Exception ex)
            {
                response.ResponseCode = 400;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<APIResponse> Update(Customermodal data, string code)
        {
            APIResponse response = new APIResponse();

            try
            {
                var _customer = await _context.TblCustomers.FindAsync(code);
                if(_customer != null){
                    _customer.Name = data.Name;
                    _customer.Email = data.Email;
                    _customer.Phone=data.Phone;
                    _customer.IsActive=data.IsActive;
                    _customer.Creditlimit = data.Creditlimit;
                    await _context.SaveChangesAsync();
                    response.ResponseCode = 200;
                    response.Result = "pass";
                }else
                {
                    response.ResponseCode = 404;
                    response.Message = "Data not found";
                }
            }
            catch (Exception ex)
            {
                
                response.ResponseCode = 400;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}