using Cinema.DAL.Interfaces;

namespace Cinema.DAL.Entities;
public class Movie : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public float RatingScore { get; set; }
    public TimeSpan Duration { get; set; }
    public DateTime? ReleaseDate { get; set; }
    public string PosterUrl { get; set; } = null!;
    public string TrailerUrl { get; set; } = null!;

    public ICollection<Genre> Genres { get; set; } = [];
    public ICollection<Session> Sessions { get; set; } = [];
}