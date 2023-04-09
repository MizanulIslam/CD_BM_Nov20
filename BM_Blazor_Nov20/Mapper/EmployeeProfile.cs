using AutoMapper;
using BM_Blazor_Nov20.Models;
using BM_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BM_Blazor_Nov20.Mapper
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EditEmployeeModel>()
                .ForMember(dest => dest.ConfirmEmail,
                           opt => opt.MapFrom(src => src.EmailID));
            CreateMap<EditEmployeeModel, Employee>();
        }
    }
}
