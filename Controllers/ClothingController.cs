using Microsoft.AspNetCore.Mvc;
using SAOnlineMart.Context;
using System.Linq;

namespace SAOnlineMart.Controllers
{
    public class ClothingController : Controller
    {
        private readonly ClothingDbContext _context;

        public ClothingController(ClothingDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var clothingItems = _context.Clothing.ToList();  // Fetch all clothing items from the database
            return View(clothingItems);  // Pass the list of clothing items to the view
        }

        public IActionResult Details(int id)
        {
            var clothingItem = _context.Clothing.FirstOrDefault(c => c.Id == id);  // Fetch the specific clothing item by ID
            if (clothingItem == null)
            {
                return NotFound();
            }
            return View(clothingItem);
        }
    }
}
