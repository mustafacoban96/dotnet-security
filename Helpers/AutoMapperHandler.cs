using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using auth_jwt_refresh_mechanism.Dtos;
using auth_jwt_refresh_mechanism.Model;
using AutoMapper;

namespace auth_jwt_refresh_mechanism.Helpers
{
    public class AutoMapperHandler : Profile
    {
       
       public AutoMapperHandler(){
           CreateMap<TblCustomer, Customermodal>().ForMember(item => item.Statusname, opt => opt.MapFrom(
                item => (item.IsActive != null && item.IsActive.Value) ? "Active" : "In active")).ReverseMap() ;
             
       }

        
    }
}