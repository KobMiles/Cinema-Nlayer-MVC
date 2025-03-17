using AutoMapper;
using Cinema.BLL.DTOs.Users;
using Cinema.DAL.Entities;

namespace Cinema.BLL.Helpers;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserDto>();

        CreateMap<User, UserDetailsDto>();
    }
}