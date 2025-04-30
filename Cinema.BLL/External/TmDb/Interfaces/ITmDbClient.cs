using Cinema.BLL.External.TmDb.DTOs;

namespace Cinema.BLL.External.TmDb.Interfaces;

public interface ITmDbClient
{
    Task<IReadOnlyCollection<TmDbMovieSearchItemDto>> SearchMovieAsync(string query);

    Task<TmDbMovieDetailsDto?> GetMovieDetailsAsync(int tmDbId);
}