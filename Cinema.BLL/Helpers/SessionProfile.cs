using AutoMapper;
using Cinema.BLL.DTOs.Sessions;
using Cinema.DAL.Entities;

namespace Cinema.BLL.Helpers;

public class SessionProfile : Profile
{
    public SessionProfile()
    {
        CreateMap<Session, SessionDto>();
        CreateMap<Session, SessionDetailsWithoutTicketsDto>();
        CreateMap<Session, SessionDetailsWithTicketsDto>();

        CreateMap<SessionCreateDto, Session>();
        CreateMap<SessionUpdateDto, Session>()
            .ReverseMap();
    }
}