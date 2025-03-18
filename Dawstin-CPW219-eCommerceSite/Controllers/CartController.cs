using Dawstin_CPW219_eCommerceSite.Game_Art_Data;
using Dawstin_CPW219_eCommerceSite.Models;
using Microsoft.AspNetCore.Mvc;

namespace Dawstin_CPW219_eCommerceSite.Controllers
{
    public class CartController : Controller
    {
        private readonly VideoGame_Art _context;

        public CartController(VideoGame_Art context)
        {
            _context = context;
        }

        public IActionResult Add(int id)
        {
            Game_Art? game_artToAdd = _context.Game_Arts.Where(g => g.Game_ArtId == id).SingleOrDefault();

            if(game_artToAdd == null)
            {
                // Game or Art with specified id does not exist
                TempData["Message"] = "Sorry that game or painting no longer exists";
                return RedirectToAction("Index", "Game_Art");
            }

            // Todo: Add item to a shopping cart cookie
            TempData["Message"] = "Item added to cart";
            return RedirectToAction("Index", "Game_Art");
        }
    }
}
