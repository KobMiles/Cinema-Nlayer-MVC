using Cinema.BLL.DTOs.Genres;
using Cinema.BLL.DTOs.Sessions;

namespace Cinema.BLL.DTOs.Movies;

public class MovieDetailsDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public float RatingScore { get; set; }
    public TimeSpan Duration { get; set; }
    public DateTime? ReleaseDate { get; set; }
    public string PosterUrl { get; set; } = null!;
    public string TrailerUrl { get; set; } = null!;

    public IReadOnlyCollection<GenreDto> Genres { get; set; } = [];
    public IReadOnlyCollection<SessionDto> Sessions { get; set; } = [];
}