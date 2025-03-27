using Cinema.BLL.DTOs.Users;

namespace Cinema.BLL.Interfaces.Services;

public interface IUserService
{
    Task<UserDetailsDto> GetUserDetailsAsync(string userId);
}