using System.Text.Json.Serialization;

namespace Cinema.BLL.External.TmDb.DTOs;

public class TmDbTrailersResponseDto
{
    [JsonPropertyName("results")]
    public List<TmDbTrailerDto> Results { get; init; } = [];
}