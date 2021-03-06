﻿using ASPTest.BLL.DTO;
using ASPTest.DAL.Entities;
using AutoMapper;

namespace ASPTest.BLL.Util
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDTO>()
                .ForMember(dest => dest.Department, opt => opt.MapFrom(src => src.Department));

            CreateMap<UserDTO, User>()
                .ForMember(dest => dest.Department, opt => opt.Ignore());
        }
    }
}
