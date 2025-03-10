namespace Cinema.BLL.DTOs.Movies;

public class MovieDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public float RatingScore { get; set; }
    public TimeSpan Duration { get; set; }
    public DateTime? ReleaseDate { get; set; }
    public string PosterUrl { get; set; } = null!;
    public string TrailerUrl { get; set; } = null!;
}