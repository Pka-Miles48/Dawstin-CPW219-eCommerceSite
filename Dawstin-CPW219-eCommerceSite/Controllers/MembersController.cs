using Dawstin_CPW219_eCommerceSite.Game_Art_Data;
using Dawstin_CPW219_eCommerceSite.Models;
using Microsoft.AspNetCore.Mvc;

namespace Dawstin_CPW219_eCommerceSite.Controllers
{
    public class MembersController : Controller
    {
        private readonly VideoGame_Art _context;

        public MembersController(VideoGame_Art context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel regModel)
        {
            if (ModelState.IsValid)
            {
                // Map RegisterViewModel data to Member object
                Member newMember = new()
                {
                    Email = regModel.Email,
                    Password = regModel.Password
                };

                _context.Members.Add(newMember);
                await _context.SaveChangesAsync();

                // Redirect to home page
                return RedirectToAction("Index", "Home");
            }

            return View(regModel);
        }
    }
}
