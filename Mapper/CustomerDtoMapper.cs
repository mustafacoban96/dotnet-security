using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using auth_jwt_refresh_mechanism.Dtos;
using auth_jwt_refresh_mechanism.Model;

namespace auth_jwt_refresh_mechanism.Mapper
{
    public static class CustomerDtoMapper
    {

        public static CustomerDto  ToCustomerModal(this TblCustomer customerModel){
            return new CustomerDto{
                Code = customerModel.Code,
                Name = customerModel.Name,
                Email = customerModel.Email,
                Phone = customerModel.Phone,
                Creditlimit = customerModel.Creditlimit,
                IsActive = customerModel.IsActive,
                TaxCode = customerModel.Taxcode
            };
        } 
    }
}