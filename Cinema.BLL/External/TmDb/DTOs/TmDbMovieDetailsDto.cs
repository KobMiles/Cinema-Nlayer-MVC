using System.Text.Json.Serialization;

namespace Cinema.BLL.External.TmDb.DTOs;

public class TmDbMovieDetailsDto
{
    [JsonPropertyName("id")]
    public int Id { get; init; }

    [JsonPropertyName("title")]
    public string Title { get; init; } = null!;

    [JsonPropertyName("overview")]
    public string? Overview { get; init; }

    [JsonPropertyName("vote_average")]
    public float VoteAverage { get; init; }

    [JsonPropertyName("runtime")]
    public int? Runtime { get; init; }

    [JsonPropertyName("release_date")]
    public string? ReleaseDate { get; init; }

    [JsonPropertyName("poster_path")]
    public string? PosterPath { get; init; }

    [JsonPropertyName("genres")]
    public List<TmDbGenreDto> Genres { get; init; } = [];


    [JsonIgnore]
    public string PosterUrl { get; set; } = string.Empty;

    [JsonIgnore]
    public string TrailerUrl { get; set; } = string.Empty;
}