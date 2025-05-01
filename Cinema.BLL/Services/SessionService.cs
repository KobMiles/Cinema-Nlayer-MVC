using AutoMapper;
using Cinema.BLL.DTOs.Sessions;
using Cinema.BLL.Interfaces.Services;
using Cinema.DAL.Entities.Specifications.Sessions;
using Cinema.DAL.Entities;
using Cinema.DAL.Interfaces.Repositories;
using Cinema.BLL.DTOs.Halls;
using Cinema.BLL.DTOs.Movies;
using Cinema.BLL.DTOs.Seats;
using Cinema.DAL.Entities.Specifications.Seats;

namespace Cinema.BLL.Services;

public class SessionService(IUnitOfWork unitOfWork, IMapper mapper) : ISessionService
{
    public async Task<IEnumerable<SessionDetailsWithoutTicketsDto>> GetAllAsync()
    {
        var spec = new SessionsWithMovieAndHallSpecification();
        var list = await unitOfWork.Sessions.ListAsync(spec);

        return mapper.Map<IEnumerable<SessionDetailsWithoutTicketsDto>>(list);
    }

    public async Task<SessionDetailsWithoutTicketsDto?> GetByIdAsync(int id)
    {
        var spec = new SessionByIdWithMovieAndHallSpec(id);
        var e = await unitOfWork.Sessions.FirstOrDefaultAsync(spec);

        return e == null
            ? null
            : mapper.Map<SessionDetailsWithoutTicketsDto>(e);
    }

    public async Task<SessionDetailsWithTicketsDto?> GetWithTicketsAsync(int id)
    {
        var spec = new SessionByIdWithMovieAndHallSpec(id, includeTickets: true);
        var session = await unitOfWork.Sessions.FirstOrDefaultAsync(spec);
        if (session == null) 
            return null;

        var dto = mapper.Map<SessionDetailsWithTicketsDto>(session);

        var seats = await unitOfWork.Seats.ListAsync(new SeatsByHallSpec(session.HallId));
        dto.Seats = mapper.Map<IReadOnlyCollection<SeatDto>>(seats);

        return dto;
    }

    public async Task CreateAsync(SessionCreateDto dto)
    {
        var entity = mapper.Map<Session>(dto);
        await unitOfWork.Sessions.AddAsync(entity);

        await unitOfWork.SaveAsync();
    }

    public async Task UpdateAsync(SessionUpdateDto dto)
    {
        var spec = new SessionByIdWithMovieAndHallSpec(dto.Id);
        var session = await unitOfWork.Sessions.FirstOrDefaultAsync(spec)
                ?? throw new KeyNotFoundException($"Session {dto.Id} not found");
        mapper.Map(dto, session);

        await unitOfWork.Sessions.UpdateAsync(session);
        await unitOfWork.SaveAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var spec = new SessionByIdWithMovieAndHallSpec(id);
        var e = await unitOfWork.Sessions.FirstOrDefaultAsync(spec);
        if (e != null)
        {
            await unitOfWork.Sessions.DeleteAsync(e);
            await unitOfWork.SaveAsync();
        }
    }

    public async Task<IEnumerable<MovieDto>> GetMovieLookupAsync()
    {
        var movies = await unitOfWork.Movies.ListAsync();

        return mapper.Map<IEnumerable<MovieDto>>(movies);
    }

    public async Task<IEnumerable<HallDto>> GetHallLookupAsync()
    {
        var halls = await unitOfWork.Halls.ListAsync();

        return mapper.Map<IEnumerable<HallDto>>(halls);
    }

    public async Task<SessionUpdateDto?> GetForEditAsync(int id)
    {
        var spec = new SessionByIdWithMovieAndHallSpec(id);
        var entity = await unitOfWork.Sessions.FirstOrDefaultAsync(spec);
        if (entity == null) 
            return null;

        return mapper.Map<SessionUpdateDto>(entity);
    }
}