using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_ASP.NET.Data;

namespace Web_ASP.NET.Controllers
{
    public class BuildCityController : Controller
    {
        private readonly ApplicationDbContext _context;
        public BuildCityController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var buildCity = await _context.Cities
                .Include(c => c.Area)
                    .ThenInclude(c => c.Country)
                    .ThenInclude(c => c.Capital)
                .Include(c => c.Area)
                .ThenInclude(c => c.RegionCapital)
                .Where(c => c.Name == "Mykolaivska Oblast")
                .ToListAsync();
            return View();
        }
    }
}
