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
        public IActionResult Create(Game_Art game_Art)
        {
            if (ModelState.IsValid)
            {
                _context.Game_Arts.Add(game_Art); // Prepares insert
                _context.SaveChanges(); // Excecutes pending insert

                ViewData["Message"] = $"{game_Art.Title} was added successfully!";
                return View();
            }

            return View(game_Art);
        }
    }
}
