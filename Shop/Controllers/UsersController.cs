using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.Data;
using Shop.Filters;
using Shop.Models;
using Shop.ViewModels;
using SessionExtensions = Shop.Extensions.SessionExtensions;

namespace Shop.Controllers
{
    public class UsersController : Controller
    {
        private readonly ShopContext _context;

        private User? _user
        {
            get
            {
                int? userId = HttpContext.Session.GetInt32(SessionExtensions.UserIdKey);
                return userId is null ? null : _context.Users.First(user => user.Id == userId);
            }
        }

        public UsersController(ShopContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return RedirectToAction(nameof(Index), controllerName: "Home");
        }
        [UserLogindedFilter]
        public IActionResult Details()
        {
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

            HttpContext.Session.SetInt32(SessionExtensions.UserIdKey, user.Id);
            HttpContext.Session.SetString(SessionExtensions.UserNameKey, user.Name);
            HttpContext.Session.SetString(SessionExtensions.UserAdminKey, user.IsAdmin.ToString());

            return RedirectToAction(nameof(Index), controllerName: "Home");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
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

        [UserLogindedFilter]
        public IActionResult Edit()
        {
            return View(_user);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction(nameof(Index), controllerName: "Home");
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("Name,Email,Phone,Password")] User user)
        {
            if (ModelState.IsValid)
            {
                _context.Update(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Details));
            }
            return View(user);

        }
    }
}
