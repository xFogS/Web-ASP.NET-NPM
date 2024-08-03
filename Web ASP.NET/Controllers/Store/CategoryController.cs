using Microsoft.AspNetCore.Mvc;
using Web_ASP.NET.Data;
using Web_ASP.NET.Models.Enteties.Store;

namespace Web_ASP.NET.Controllers.Store
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index() { return View(); }
        public IActionResult Create(string title)
        {
            Category category = new();
            category.Title = title;

            _context.Add(category);
            _context.SaveChangesAsync();

            ViewData["CategoryTitle"] = title;
            return View();
        }
    }
}
