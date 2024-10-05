using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Web_ASP.NET.Data;
using Web_ASP.NET.Models.Enteties;

namespace Web_ASP.NET.Controllers.AreaOfCountry.API
{
    public class ApiPageOfCountryController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ApiPageOfCountryController(ApplicationDbContext context) { _context = context; }
        // GET: Country
        public IActionResult Index() { return View(); }
        public IActionResult Create() { return View(); }
        public async Task<IActionResult> Edit(int id) 
        {
            var country = await _context.Countries
                .FindAsync(id);
            if (country == null) return NotFound();
            return View(country);
        }
        //public async Task<IActionResult> Delete(int id)
        //{
        //    var country = await _context.Countries
        //        .FindAsync(id);
        //    if (country == null) return NotFound();
        //    return View(country);
        //}

    }
}
