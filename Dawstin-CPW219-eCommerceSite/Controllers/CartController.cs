using Dawstin_CPW219_eCommerceSite.Game_Art_Data;
using Dawstin_CPW219_eCommerceSite.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Dawstin_CPW219_eCommerceSite.Controllers
{
    public class CartController : Controller
    {
        private readonly VideoGame_Art _context;
        private const string Cart = "ShoppingCart";

        public CartController(VideoGame_Art context)
        {
            _context = context;
        }

        public IActionResult Add(int id)
        {
            Game_Art? game_artToAdd = _context.Game_Arts.Where(g => g.Game_ArtId == id).SingleOrDefault();

            if (game_artToAdd == null)
            {
                // Game or Art with specified id does not exist
                TempData["Message"] = "Sorry that game or painting no longer exists";
                return RedirectToAction("Index", "Game_Art");
            }

            CartGameAndArtViewModel cartGame_Art = new()
            {
                Game_ArtId = game_artToAdd.Game_ArtId,
                Title = game_artToAdd.Title,
                Price = game_artToAdd.Price
            };

            List<CartGameAndArtViewModel> cartGameAndArts = GetExistingCartData();
            cartGameAndArts.Add(cartGame_Art);
            WriteShoppingCartCookie(cartGameAndArts);

            TempData["Message"] = "Item added to cart";
            return RedirectToAction("Index", "Game_Art");
        }

        private void WriteShoppingCartCookie(List<CartGameAndArtViewModel> cartGameAndArts)
        {
            string cookieData = JsonConvert.SerializeObject(cartGameAndArts);


            HttpContext.Response.Cookies.Append(Cart, cookieData, new CookieOptions()
            {
                Expires = DateTimeOffset.Now.AddYears(1)
            });
        }

        /// <summary>
        /// Return the current list of video games and paintings in the users shopping
        /// cart cookie. If there is no choice, an empty list will be returned
        /// </summary>
        /// <returns></returns>
        private List<CartGameAndArtViewModel> GetExistingCartData()
        {
            string? cookie = HttpContext.Request.Cookies[Cart];
            if (string.IsNullOrWhiteSpace(cookie))
            {
                return new List<CartGameAndArtViewModel>();
            }

            return JsonConvert.DeserializeObject<List<CartGameAndArtViewModel>>(cookie);
        }

        public IActionResult Summary()
        {
            List<CartGameAndArtViewModel> cartGameAndArts = GetExistingCartData();
            return View(cartGameAndArts);
        }

        public IActionResult Remove(int id)
        {
            List<CartGameAndArtViewModel> cartGameAndArts = GetExistingCartData();

            CartGameAndArtViewModel? targetGame =
                cartGameAndArts.Where(g => g.Game_ArtId == id).FirstOrDefault();

            cartGameAndArts.Remove (targetGame);

            WriteShoppingCartCookie(cartGameAndArts);

            return RedirectToAction(nameof(Summary));
        }
    }
}
