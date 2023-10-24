using AutoMapper;
using WebAPITest.Modeles;
using WebAPITest.DTO;
using WebAPITest.DAL;

namespace WebAPITest.DTOMapper
{
    public class MappingProfile : Profile
    {

        // 2 ways mapping just in case. Manually mapped private props to getters and setters.
        public MappingProfile() 
        {

            CreateMap<Users, LoginDTO>()
           .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.email))
           .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.password));

            //Mirror mapping
            CreateMap<LoginDTO,Users>();

        }


    }
}
