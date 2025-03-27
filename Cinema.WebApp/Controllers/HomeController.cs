using System.Diagnostics;
using Cinema.BLL.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Cinema.WebApp.ViewModels;

namespace Cinema.WebApp.Controllers;

public class HomeController(IMovieService movieService) : Controller
{
    public async Task<IActionResult> IndexAsync()
    {
        var movies = await movieService.GetMoviesWithActiveSessionsAsync();
        return View(movies);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}