using Cinema.BLL.DTOs.Sessions;
using Cinema.BLL.Interfaces.Services;
using Cinema.BLL.Services;
using Cinema.DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Cinema.WebApp.Controllers;

public class SessionController(ISessionService sessionService) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        return View(await sessionService.GetAllAsync());
    }

    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {
        var vm = await sessionService.GetWithTicketsAsync(id);
        if (vm == null) 
            return NotFound();

        return View(vm);
    }

    [Authorize(Roles = "Admin")]
    [HttpGet]
    public async Task<IActionResult> Create()
    {
        await PopulateLookups();

        return View(new SessionCreateDto { StartTime = DateTime.Now });
    }

    [Authorize(Roles = "Admin")]
    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(SessionCreateDto dto)
    {
        if (!ModelState.IsValid)
        {
            await PopulateLookups();

            return View(dto);
        }

        await sessionService.CreateAsync(dto);

        return RedirectToAction("Index");
    }

    [Authorize(Roles = "Admin")]
    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var dto = await sessionService.GetForEditAsync(id);
        if (dto == null)
            return NotFound();

        await PopulateLookups();
        return View(dto);
    }

    [Authorize(Roles = "Admin")]
    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(SessionUpdateDto dto)
    {
        if (!ModelState.IsValid)
        {
            await PopulateLookups();

            return View(dto);
        }

        await sessionService.UpdateAsync(dto);

        return RedirectToAction(nameof(Index));
    }

    [Authorize(Roles = "Admin")]
    [HttpPost("{id}"), ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
        await sessionService.DeleteAsync(id);

        return RedirectToAction("Index");
    }

    private async Task PopulateLookups()
    {
        var movies = await sessionService.GetMovieLookupAsync();
        ViewBag.MovieList = new SelectList(movies, "Id", "Name");

        var halls = await sessionService.GetHallLookupAsync();
        ViewBag.HallList = new SelectList(halls, "Id", "Id");
    }
}