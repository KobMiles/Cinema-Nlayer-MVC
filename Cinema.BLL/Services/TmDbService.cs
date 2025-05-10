using AutoMapper;
using Cinema.BLL.DTOs.Movies;
using Cinema.BLL.External.TmDb.Interfaces;
using Cinema.BLL.Interfaces.Services;

namespace Cinema.BLL.Services;

public class TmDbService(ITmDbClient client, IMapper mapper) : ITmDbService
{
    public async Task<IEnumerable<MovieDto>> SearchMoviesAsync(string query)
    {
        var items = await client.SearchMovieAsync(query);

        return mapper.Map<IEnumerable<MovieDto>>(items);
    }
    public async Task<MovieCreateDto?> GetMovieForCreateAsync(int tmdbId)
    {
        var details = await client.GetMovieDetailsAsync(tmdbId);
        if (details == null)
            return null;

        return mapper.Map<MovieCreateDto>(details);
    }
}
