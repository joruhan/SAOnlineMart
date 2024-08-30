using Microsoft.AspNetCore.Mvc;

namespace SAOnlineMart.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult ShoppingCartController()
        {
            return View(); // This will look for Views/Account/ShoppingCart.cshtml
        }
    }
}
