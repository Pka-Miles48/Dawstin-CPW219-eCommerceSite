using Dawstin_CPW219_eCommerceSite.Game_Art_Data;
using Dawstin_CPW219_eCommerceSite.Models;
using Microsoft.AspNetCore.Mvc;

namespace Dawstin_CPW219_eCommerceSite.Controllers
{
    public class Game_ArtController : Controller
    {
        private readonly VideoGame_Art _context;

        public Game_ArtController(VideoGame_Art context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Game_Art game_Art)
        {
            if (ModelState.IsValid)
            {
                _context.Game_Arts.Add(game_Art);   // Prepares insert
                // For async code info in the tutorial
                // https://learn.microsoft.com/en-us/aspnet/core/data/ef-mvc/intro?view=aspnetcore-8.0&tabs=visual-studio
                await _context.SaveChangesAsync();  // Excecutes pending insert

                ViewData["Message"] = $"{game_Art.Title} was added successfully!";
                return View();
            }

            return View(game_Art);
        }
    }
}
