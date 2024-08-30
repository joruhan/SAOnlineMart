using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SAOnlineMart.Context;
using SAOnlineMart.Models;
using SAOnlineMart.Areas.Admin.Model;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace OnlineMart.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var usernameExists = await _context.Users.AnyAsync(u => u.userName == model.Username); // Ensure correct property name
                var emailExists = await _context.Users.AnyAsync(u => u.userEmail == model.Email);

                if (usernameExists)
                {
                    ModelState.AddModelError("Username", "Username already exists.");
                }
                else if (emailExists)
                {
                    ModelState.AddModelError("Email", "Email already in use.");
                }
                else
                {
                    var hashedPassword = BCrypt.Net.BCrypt.HashPassword(model.Password);

                    var user = new UserAccount
                    {
                        userName = model.Username, // Ensure correct property name
                        userEmail = model.Email,
                        phoneNumber = model.PhoneNumber,
                        userPassword = hashedPassword
                    };

                    _context.Users.Add(user);
                    await _context.SaveChangesAsync();

                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.userName) // Ensure correct property name
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                    TempData["Message"] = "Registration successful!";
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                TempData["Message"] = "Registration unsuccessful. Please check the errors and try again.";
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _context.Users
                .SingleOrDefaultAsync(u => u.userName == model.UsernameOrEmail || u.userEmail == model.UsernameOrEmail);

            if (user == null)
            {
                // Username or email does not exist
                TempData["Message"] = "Username or email does not exist.";
                return View(model);
            }

            if (!BCrypt.Net.BCrypt.Verify(model.Password, user.userPassword)) // Verify hashed password
            {
                TempData["Message"] = "Incorrect password.";
                return View(model);
            }

            // Create claims for the user
            var claims = new List<Claim>
    {
        new Claim(ClaimTypes.Name, user.userName),
        new Claim(ClaimTypes.Role, user.Role)
    };

            // Create claims identity
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            // Create claims principal
            var principal = new ClaimsPrincipal(identity);

            // Sign in the user
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            TempData["Message"] = "Login successful!";
            if (user.Role == "Admin")
            {
                return RedirectToAction("Index", "Admin", new { area = "Admin" });
            }

            return RedirectToAction("Index", "Home");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            TempData["Message"] = "You have been logged out successfully.";
            return RedirectToAction("Login");
        }

        public IActionResult ShoppingCart()
        {
            return View(); // This will look for Views/ShoppingCart.cshtml
        }

        public IActionResult Jewelry()
        {
            return View();
        }

        public IActionResult Clothing()
        {
            return View();
        }
    }
}
