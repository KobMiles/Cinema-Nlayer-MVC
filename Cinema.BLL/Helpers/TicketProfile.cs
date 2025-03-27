using AutoMapper;
using Cinema.BLL.DTOs.Tickets;
using Cinema.DAL.Entities;

namespace Cinema.BLL.Helpers;

public class TicketProfile : Profile
{
    public TicketProfile()
    {
        CreateMap<Ticket, TicketDto>();
        CreateMap<Ticket, TicketDetailsDto>();

        CreateMap<TicketCreateDto, Ticket>()
            .ForMember(dest => dest.TicketNumber, opt => opt.Ignore());

        CreateMap<TicketUpdateDto, Ticket>()
            .ForMember(dest => dest.TicketNumber, opt => opt.Ignore());
    }
}