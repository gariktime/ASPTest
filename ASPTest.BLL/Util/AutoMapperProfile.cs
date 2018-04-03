using ASPTest.BLL.DTO;
using ASPTest.DAL.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPTest.BLL.Util
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDTO>()
                .ForMember(dest => dest.Department, opt => opt.MapFrom(src => src.Department));
        }
    }
}
