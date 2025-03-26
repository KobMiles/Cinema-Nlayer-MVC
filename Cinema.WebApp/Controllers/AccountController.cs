using Cinema.BLL.DTOs.Users;
using Cinema.BLL.Interfaces.Services;
using Cinema.WebApp.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Cinema.WebApp.Controllers;

public class AccountController(IAuthService authService, IUserService userService) : Controller
{

    [HttpGet, RedirectAuthenticated]
    public IActionResult Register() => View();

    [HttpPost]
    public async Task<IActionResult> Register(UserRegisterDto model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var result = await authService.RegisterAsync(model);
        if (result.Succeeded)
        {
            TempData["Success"] = "Registration successful! You can now log in.";
            return RedirectToAction(nameof(Login));
        }

        foreach (var error in result.Errors)
            ModelState.AddModelError(string.Empty, error.Description);

        return View(model);
    }

    [HttpGet, RedirectAuthenticated]
    public IActionResult Login(string? returnUrl = null)
    {
        ViewData["ReturnUrl"] = returnUrl;
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(UserLoginDto model, string? returnUrl = null)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var result = await authService.LoginAsync(model);

        if (result.Succeeded)
        {
            if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        ModelState.AddModelError(string.Empty, "Invalid login attempt.");
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        await authService.LogoutAsync();
        return RedirectToAction(nameof(Login));
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> Profile()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        try
        {
            var userDetails = await userService.GetUserDetailsAsync(userId!);
            return View(userDetails);
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }
}
