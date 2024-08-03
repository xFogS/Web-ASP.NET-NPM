using Microsoft.AspNetCore.Mvc;
using Web_ASP.NET.Data;
using Web_ASP.NET.Models.Enteties.Store;

namespace Web_ASP.NET.Controllers.Store
{
    public class VendorController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VendorController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index() { return View(); }
        public IActionResult Create(string name) 
        {
            Vendor vendor = new();
            vendor.Name = name;

            _context.Add(vendor);
            _context.SaveChangesAsync();

            ViewData["VendorName"] = name;  
            return View(); 
        }
    }
}
