using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_ASP.NET.Data;
using Web_ASP.NET.Models.Enteties.Store;

namespace Web_ASP.NET.Controllers.Store
{
    public class TagController : Controller
    {
        private readonly ApplicationDbContext _context;
        /// <summary>
        /// class constructor 
        /// </summary>
        /// <param name="context">connect to db</param>
        public TagController(ApplicationDbContext context)
        {
            _context = context;
        }
        //get
        public IActionResult Index()
        {
            return View();
        }
        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(string title)
        {
            Tag tag = new();
            tag.Title = title;

            _context.Add(tag);
            _context.SaveChangesAsync();

            ViewData["TagTitle"] = title;
            /*Console.WriteLine($"\n{ViewData["TagTitle"]}");*/
            return View();
        }
    }
}
