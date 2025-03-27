using AutoMapper;
using Cinema.BLL.DTOs.Users;
using Cinema.DAL.Entities;

namespace Cinema.BLL.Helpers;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserDto>();
        CreateMap<User, UserDetailsDto>()
            .ForMember(dest => dest.Tickets, 
                opt => opt.MapFrom(src => src.Tickets));

        CreateMap<UserRegisterDto, User>()
            .ForMember(dest => dest.UserName, 
                opt => opt.MapFrom(src => src.Email));
    }
}