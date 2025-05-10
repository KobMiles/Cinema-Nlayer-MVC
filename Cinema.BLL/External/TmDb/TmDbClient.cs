using Microsoft.Extensions.Options;
using System.Net.Http.Json;
using Cinema.BLL.External.TmDb.DTOs;
using Cinema.BLL.External.TmDb.Interfaces;

namespace Cinema.BLL.External.TmDb;

public class TmDbClient(
    HttpClient http,
    IOptionsSnapshot<TmDbOptions> options)
    : ITmDbClient
{
    private readonly TmDbOptions _options = options.Value;

    public async Task<IReadOnlyCollection<TmDbMovieSearchItemDto>> SearchMovieAsync(
        string query)
    {
        var url = $"search/movie?query={Uri.EscapeDataString(query)}" +
                  $"&api_key={_options.ApiKey}&language={_options.Language}&include_adult=false";

        var raw = await http.GetFromJsonAsync<TmDbSearchMovieResponseDto>(url);
        if (raw is null)
            return [];

        foreach (var item in raw.Results)
            item.PosterUrl = BuildPosterUrl(item.PosterPath);

        return raw.Results;
    }

    public async Task<TmDbMovieDetailsDto?> GetMovieDetailsAsync(int id)
    {
        var urlDetails = $"movie/{id}?api_key={_options.ApiKey}&language={_options.Language}";
        var dto = await http.GetFromJsonAsync<TmDbMovieDetailsDto>(urlDetails);
        if (dto is null)
            return null;

        dto.PosterUrl = BuildPosterUrl(dto.PosterPath);

        dto.TrailerUrl = await GetTrailerUrlAsync(id);

        return dto;
    }

    private string BuildPosterUrl(string? path)
    {
       return string.IsNullOrWhiteSpace(path)
            ? string.Empty
            : $"{_options.ImageBaseUrl}{_options.PosterSize}{path}";
    }

    private async Task<string> GetTrailerUrlAsync(int id)
    {
        var urlTrailer = $"movie/{id}/videos?api_key={_options.ApiKey}&language={_options.Language}";
        var response = await http.GetFromJsonAsync<TmDbTrailersResponseDto>(urlTrailer);

        var trailerKey = response?.Results
            .FirstOrDefault(v =>
                v.Site.Equals("YouTube", StringComparison.OrdinalIgnoreCase) &&
                v.Type.Equals("Trailer", StringComparison.OrdinalIgnoreCase))
            ?.Key;

        return trailerKey is null 
            ? string.Empty 
            : $"{_options.YoutubeBase}{trailerKey}";
    }
}