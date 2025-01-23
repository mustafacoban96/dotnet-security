using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using auth_jwt_refresh_mechanism.Dtos;
using auth_jwt_refresh_mechanism.Helpers;
using auth_jwt_refresh_mechanism.Model;

namespace auth_jwt_refresh_mechanism.Interfaces.IRepository
{
    public interface ICustomerRepo
    {
        Task<List<Customermodal>> GetAll();
        Task<Customermodal> GetByCode(string code);
        Task<APIResponse> Remove(string code);
        Task<APIResponse> Create(Customermodal data);
        Task<APIResponse> Update(Customermodal data,string code);
    }
}