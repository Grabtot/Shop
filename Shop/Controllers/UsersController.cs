using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.Data;
using Shop.Models;
using Shop.ViewModels;

namespace Shop.Controllers
{
    public class UsersController : Controller
    {
        private readonly ShopContext _context;
        private const string _userKey = "user";

        private User? _user
        {
            get
            {
                int? userId = HttpContext.Session.GetInt32(_userKey);
                return userId is null ? null : _context.Users.First(user => user.Id == userId);
            }
        }

        public UsersController(ShopContext context)
        {
            _context = context;
        }

        public IActionResult Details()
        {
            if (_user is null)
            {
                return RedirectToAction(nameof(Login));
            }
            return View(_user);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            User? user = await _context.Users.FirstOrDefaultAsync(user => user.Email == email && user.Password == password);
            if (user is null)
            {
                return View();
            }
            HttpContext.Session.SetInt32(_userKey, user.Id);
            HttpContext.Session.SetString("userName", user.Name);
            return RedirectToAction(nameof(Index), controllerName: "Home");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([Bind("Name, Password, ConfirmPassword,Email,Phone")] UserViewModel userModel)
        {
            if (ModelState.IsValid)
            {
                User user = new(userModel);
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), controllerName: "Home");
            }
            return View(userModel);
        }
    }
}
