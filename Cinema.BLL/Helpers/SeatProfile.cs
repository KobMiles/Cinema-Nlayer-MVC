using AutoMapper;
using Cinema.BLL.DTOs.Seats;
using Cinema.DAL.Entities;

namespace Cinema.BLL.Helpers;

public class SeatProfile : Profile
{
    public SeatProfile()
    {
        CreateMap<Seat, SeatDto>();

        CreateMap<Seat, SeatDetailsDto>();
    }
}