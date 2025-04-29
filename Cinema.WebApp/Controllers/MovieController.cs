using Cinema.BLL.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.WebApp.Controllers;

public class MovieController(IMovieService movieService) : Controller
{
    [HttpGet] public async Task<IActionResult> Details(int id)
    {
        var movieDetails = await movieService.GetMovieDetailsAsync(id);

        if (movieDetails == null)
            return NotFound();

        return View(movieDetails);
    }
}