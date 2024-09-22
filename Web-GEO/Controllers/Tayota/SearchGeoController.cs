using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_GEO.Data;

namespace Web_GEO.Controllers.Tayota
{
    public class SearchGeoController : Controller
    {
        private readonly ApplicationDbContext _context;
        public SearchGeoController(ApplicationDbContext context) { _context = context; }
        public IActionResult Index()
        {
            return View(_context.ColorModels.ToList());
        }
        public IActionResult SearchPage() { return View("Search"); }
        [HttpGet]
        public async Task<IActionResult> Search(string search = null, int pageNumber = 1, int pageSize = 2)
        {
            var model = await _context.ColorModels.AsQueryable()
                  .Include(m => m.ConfColor)
                  .Where(m => !String.IsNullOrEmpty(search) ? EF.Functions.Like(m.Name, $"%{search}%") : true)
                  .OrderBy(m => m.Name)
                  .Skip((pageNumber - 1) * pageSize)
                  .Take(pageSize)
                  .ToListAsync();
            return View(model);
        }
    }
}
