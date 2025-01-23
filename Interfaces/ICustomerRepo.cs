using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using auth_jwt_refresh_mechanism.Dtos;
using auth_jwt_refresh_mechanism.Model;

namespace auth_jwt_refresh_mechanism.Interfaces.IRepository
{
    public interface ICustomerRepo
    {
        Task<List<CustomerDto>> GetAll();
    }
}