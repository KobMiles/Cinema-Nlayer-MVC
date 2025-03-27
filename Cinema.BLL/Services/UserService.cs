using AutoMapper;
using Cinema.BLL.DTOs.Users;
using Cinema.BLL.Interfaces.Services;
using Cinema.DAL.Entities.Specifications.Users;
using Cinema.DAL.Interfaces.Repositories;

namespace Cinema.BLL.Services;

public class UserService(IUnitOfWork unitOfWork, IMapper mapper) : IUserService
{
    public async Task<UserDetailsDto> GetUserDetailsAsync(string userId)
    {
        var spec = new UserByIdWithTicketsSpec(userId);
        var user = await unitOfWork.Users.FirstOrDefaultAsync(spec) ?? throw new KeyNotFoundException($"User with id: {userId} not found.");

        var userDetailsDto = mapper.Map<UserDetailsDto>(user);

        return userDetailsDto;
    }
}