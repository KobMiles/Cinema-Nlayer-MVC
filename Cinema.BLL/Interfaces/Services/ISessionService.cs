using Cinema.BLL.DTOs.Halls;
using Cinema.BLL.DTOs.Movies;
using Cinema.BLL.DTOs.Sessions;

namespace Cinema.BLL.Interfaces.Services;

public interface ISessionService
{
    Task<IEnumerable<SessionDetailsWithoutTicketsDto>> GetAllAsync();
    Task<SessionDetailsWithoutTicketsDto?> GetByIdAsync(int id);
    Task<SessionDetailsWithTicketsDto?> GetWithTicketsAsync(int id);
    Task CreateAsync(SessionCreateDto dto);
    Task UpdateAsync(SessionUpdateDto dto);
    Task DeleteAsync(int id);
    Task<IEnumerable<MovieDto>> GetMovieLookupAsync();
    Task<IEnumerable<HallDto>> GetHallLookupAsync();
    Task<SessionUpdateDto?> GetForEditAsync(int id);
}