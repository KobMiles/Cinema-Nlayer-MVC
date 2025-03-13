using Cinema.BLL.DTOs.Movies;

namespace Cinema.BLL.DTOs.Genres;

public class GenreDetailsDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;

    public IReadOnlyCollection<MovieDto> Movies { get; set; } = [];
}