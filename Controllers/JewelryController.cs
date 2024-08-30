using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SAOnlineMart.Context;
using SAOnlineMart.Models;
using System.Threading.Tasks;

namespace SAOnlineMart.Controllers
{
    public class JewelryController : Controller
    {
        private readonly JewelryDbContext _context;

        public JewelryController(JewelryDbContext context)
        {
            _context = context;
        }

        // Example action for listing Jewelry items
        public async Task<IActionResult> Index()
        {
            var jewelryList = await _context.Jewelry.ToListAsync();
            return View("Jewelry", jewelryList); // Specify the view name "Jewelry"
        }


        // Example action for getting details of a specific Jewelry item
        public async Task<IActionResult> Details(int id)
        {
            var jewelryItem = await _context.Jewelry
                .FirstOrDefaultAsync(j => j.Id == id);

            if (jewelryItem == null)
            {
                // Log or debug here
                return NotFound();
            }

            return View(jewelryItem);
        }

    }
}
