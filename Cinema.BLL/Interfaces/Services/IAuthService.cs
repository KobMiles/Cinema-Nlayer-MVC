using Cinema.BLL.DTOs.Users;
using Microsoft.AspNetCore.Identity;
using IdentitySignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace Cinema.BLL.Interfaces.Services;

public interface IAuthService
{
    Task<IdentityResult> RegisterAsync(UserRegisterDto registerDto);

    Task<IdentitySignInResult> LoginAsync(UserLoginDto loginDto);

    Task LogoutAsync();
}