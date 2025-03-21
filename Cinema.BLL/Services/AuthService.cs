using AutoMapper;
using Cinema.BLL.DTOs.Users;
using Cinema.BLL.Interfaces.Services;
using Cinema.DAL.Entities;
using Microsoft.AspNetCore.Identity;

namespace Cinema.BLL.Services;

public class AuthService(UserManager<User> userManager, SignInManager<User> signInManager, IMapper mapper) : IAuthService
{
    public async Task<IdentityResult> RegisterAsync(UserRegisterDto registerDto)
    {
        var user = mapper.Map<User>(registerDto);

        var result = await userManager.CreateAsync(user, registerDto.Password);

        return result;
    }

    public async Task<SignInResult> LoginAsync(UserLoginDto loginDto)
    {
        var user = await userManager.FindByEmailAsync(loginDto.Email);
        if (user == null)
        {
            return SignInResult.Failed;
        }

        var result = await signInManager.PasswordSignInAsync(user, loginDto.Password, loginDto.RememberMe, lockoutOnFailure: true);
        return result;
    }

    public async Task LogoutAsync()
    {
        await signInManager.SignOutAsync();
    }
}