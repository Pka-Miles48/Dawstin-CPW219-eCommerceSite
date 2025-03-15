using Dawstin_CPW219_eCommerceSite.Game_Art_Data;
using Dawstin_CPW219_eCommerceSite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dawstin_CPW219_eCommerceSite.Controllers
{
    public class Game_ArtController : Controller
    {
        private readonly VideoGame_Art _context;

        public Game_ArtController(VideoGame_Art context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            // List<Game_Art> arts = _context.Game_Arts.ToList();
            List<Game_Art> arts = await (from game_art in _context.Game_Arts
                                         select game_art).ToListAsync();

            return View(arts);
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

        public async Task<IActionResult> Edit(int id)
        {
            Game_Art? game_artToEdit = await _context.Game_Arts.FindAsync(id);

            if (game_artToEdit == null)
            {
                return NotFound();
            }

            return View(game_artToEdit);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Game_Art game_artModel)
        {
            if (ModelState.IsValid)
            {
                _context.Game_Arts.Update(game_artModel);
                await _context.SaveChangesAsync();

                TempData["Message"] = $"{game_artModel.Title} was updated successfully!";
                return RedirectToAction("Index");
            }

            return View(game_artModel);
        }
    }
}
