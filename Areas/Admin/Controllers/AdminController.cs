using Microsoft.AspNetCore.Mvc;
using SAOnlineMart.Areas.Admin.Model;
using SAOnlineMart.Context;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace SAOnlineMart.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var users = _context.Users.Select(u => new UserAccount
            {
                UserId = u.UserId,
                userName = u.userName,
                userEmail = u.userEmail,
                phoneNumber = u.phoneNumber,
                Role = u.Role
            }).ToList();
            return View(users);
        }

        public IActionResult EditUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            var userModel = new UserAccount
            {
                UserId = user.UserId,
                userName = user.userName,
                userEmail = user.userEmail,
                phoneNumber = user.phoneNumber,
                Role = user.Role
            };

            return View(userModel);
        }

        [HttpPost]
        public IActionResult EditUser(UserAccount user)
        {
            if (ModelState.IsValid)
            {
                var userEntity = _context.Users.Find(user.UserId);
                if (userEntity == null)
                {
                    return NotFound();
                }

                userEntity.userName = user.userName;
                userEntity.userEmail = user.userEmail;
                userEntity.phoneNumber = user.phoneNumber;
                userEntity.Role = user.Role;

                _context.Users.Update(userEntity);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        public IActionResult DeleteUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            var userModel = new UserAccount
            {
                UserId = user.UserId,
                userName = user.userName,
                userEmail = user.userEmail,
                phoneNumber = user.phoneNumber,
                Role = user.Role
            };

            return View(userModel);
        }

        [HttpPost, ActionName("DeleteUser")]
        public IActionResult DeleteUserConfirmed(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
