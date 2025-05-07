using Cinema.BLL.DTOs.Movies;
using Cinema.BLL.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.WebApp.Controllers;

[Authorize(Roles = "Admin")]
public class AdminController(ITmDbService tmDbService, IMovieService movieService) : Controller
{
    [HttpGet]
    public IActionResult Create()
    {
       return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(string query)
    {
        if (string.IsNullOrWhiteSpace(query))
        {
            ModelState.AddModelError(nameof(query), "Enter query for search");

            return View();
        }

        var results = await tmDbService.SearchMoviesAsync(query);

        return View(results);
    }

    [HttpGet]
    public async Task<IActionResult> Upsert(int? tmdbId)
    {
        MovieCreateDto model;
        if (tmdbId.HasValue)
        {
            var fromTmDb = await tmDbService.GetMovieForCreateAsync(tmdbId.Value);
            if (fromTmDb == null)
                return NotFound();

            model = fromTmDb;
        }
        else
        {
            model = new MovieCreateDto();
        }

        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Upsert(MovieCreateDto dto)
    {
        if (!ModelState.IsValid)
            return View(dto);

        await movieService.CreateAsync(dto);

        return RedirectToAction(nameof(Create));
    }
}