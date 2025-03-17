using Cinema.BLL.DTOs.Tickets;

namespace Cinema.BLL.DTOs.Users;

public class UserDetailsDto
{
    public string Id { get; set; } = null!;
    public string UserName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public bool EmailConfirmed { get; set; }
    public string? PhoneNumber { get; set; }
    public bool PhoneNumberConfirmed { get; set; }

    public IReadOnlyCollection<TicketDto> Tickets { get; set; } = [];
}