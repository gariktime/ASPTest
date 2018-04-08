using ASPTest.BLL.DTO;
using ASPTest.DAL.Entities;
using AutoMapper;

namespace ASPTest.BLL.Util
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDTO>()
                .ForMember(dest => dest.Department, opt => opt.MapFrom(src => src.Department))
                .ForMember(dest => dest.DepartmentTitle, opt => opt.MapFrom(src => src.Department.Title));

            CreateMap<UserDTO, User>()
                .ForMember(dest => dest.Department, opt => opt.Ignore())
                .ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }
}
