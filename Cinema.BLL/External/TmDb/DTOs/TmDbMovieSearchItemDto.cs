using System.Text.Json.Serialization;

namespace Cinema.BLL.External.TmDb.DTOs;

public class TmDbMovieSearchItemDto
{
    [JsonPropertyName("id")]
    public int Id { get; init; }

    [JsonPropertyName("title")]
    public string Title { get; init; } = null!;

    [JsonPropertyName("poster_path")]
    public string? PosterPath { get; init; }

    [JsonIgnore]
    public string PosterUrl { get; set; } = string.Empty;
}