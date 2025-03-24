using Cinema.BLL.DTOs.Users;
using Microsoft.AspNetCore.Identity;
using IdentitySignInResult = Microsoft.AspNetCore.Identity.SignInResult;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.BLL.Interfaces.Services;

public interface IAuthService
{
    Task<IdentityResult> RegisterAsync(UserRegisterDto registerDto);
    Task<(IdentitySignInResult result, string redirectUrl)> LoginAsync(UserLoginDto loginDto, string? returnUrl, IUrlHelper urlHelper);
    Task LogoutAsync();
}
