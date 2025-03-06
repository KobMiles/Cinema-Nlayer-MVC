using Microsoft.AspNetCore.Identity;

namespace Cinema.DAL.Entities;

public class User : IdentityUser
{
    public ICollection<Ticket> Tickets { get; set; } = [];
}