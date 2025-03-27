using AutoMapper;
using Cinema.BLL.DTOs.Halls;
using Cinema.DAL.Entities;

namespace Cinema.BLL.Helpers;

public class HallProfile : Profile
{
    public HallProfile()
    {
        CreateMap<Hall, HallDto>();

        CreateMap<Hall, HallDetailsDto>();
    }
}