using System.Collections;
using Cinema.DAL.Interfaces;

namespace Cinema.DAL.Entities;
public class Genre : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public ICollection<Movie> Movies { get; set; } = [];
}