using AutoMapper;
using Cinema.BLL.DTOs.Users;
using Cinema.BLL.Interfaces.Services;
using Cinema.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using IdentitySignInResult = Microsoft.AspNetCore.Identity.SignInResult;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.BLL.Services;

public class AuthService(
    UserManager<User> userManager,
    SignInManager<User> signInManager,
    IMapper mapper) : IAuthService
{
    public async Task<IdentityResult> RegisterAsync(UserRegisterDto registerDto)
    {
        var user = mapper.Map<User>(registerDto);
        return await userManager.CreateAsync(user, registerDto.Password);
    }

    public async Task<(IdentitySignInResult result, string redirectUrl)> LoginAsync(UserLoginDto loginDto, string? returnUrl, IUrlHelper urlHelper)
    {
        var user = await userManager.FindByEmailAsync(loginDto.Email);
        if (user == null)
        {
            return (IdentitySignInResult.Failed, string.Empty);
        }

        var result = await signInManager.PasswordSignInAsync(user, loginDto.Password, loginDto.RememberMe, lockoutOnFailure: true);

        if (result.Succeeded)
        {
            var safeRedirectUrl = urlHelper.IsLocalUrl(returnUrl)
                ? returnUrl
                : urlHelper.Action("Index", "Home")!;

            return (result, safeRedirectUrl);
        }

        return (result, string.Empty);
    }

    public async Task LogoutAsync()
    {
        await signInManager.SignOutAsync();
    }
}
