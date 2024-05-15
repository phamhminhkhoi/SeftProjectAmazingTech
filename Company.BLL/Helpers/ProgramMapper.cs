using AutoMapper;
using Company.DAL.DTO.Request;
using Company.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.BLL.Helpers
{
    public class ProgramMapper : Profile
    {
        public ProgramMapper() {
            CreateMap<User, LoginRequestDTO>().ReverseMap();
            CreateMap<User, RegistrationRequestDTO>().ReverseMap();
            CreateMap<User, UserUpdateRequestDTO>().ReverseMap();
            CreateMap<User, UserCreateRequestDTO>().ReverseMap();
            CreateMap<Salary, SalaryRequestDTO>().ReverseMap();
        }
    }
}
