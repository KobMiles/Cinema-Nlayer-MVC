using System.Text.Json.Serialization;

namespace Cinema.BLL.External.TmDb.DTOs;

public sealed class TmDbSearchMovieResponseDto
{
    [JsonPropertyName("results")]
    public List<TmDbMovieSearchItemDto> Results { get; init; } = [];
}