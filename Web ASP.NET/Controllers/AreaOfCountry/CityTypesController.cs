using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Web_ASP.NET.Data;
using Web_ASP.NET.Models.Enteties;

namespace Web_ASP.NET.Controllers.AreaOfCountry
{
    public class CityTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CityTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CityTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.CityTypes.ToListAsync());
        }

        // GET: CityTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cityType = await _context.CityTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cityType == null)
            {
                return NotFound();
            }

            return View(cityType);
        }

        // GET: CityTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CityTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] CityType cityType)
        {
            /*if (ModelState.IsValid)
            {*/
            _context.Add(cityType);
            await _context.SaveChangesAsync();
            RedirectToAction(nameof(Index));
            /*}*/
            return View(cityType);
        }

        // GET: CityTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cityType = await _context.CityTypes.FindAsync(id);
            if (cityType == null)
            {
                return NotFound();
            }
            return View(cityType);
        }

        // POST: CityTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] CityType cityType)
        {
            if (id != cityType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cityType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CityTypeExists(cityType.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(cityType);
        }

        // GET: CityTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cityType = await _context.CityTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cityType == null)
            {
                return NotFound();
            }

            return View(cityType);
        }

        // POST: CityTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cityType = await _context.CityTypes.FindAsync(id);
            if (cityType != null)
            {
                _context.CityTypes.Remove(cityType);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CityTypeExists(int id)
        {
            return _context.CityTypes.Any(e => e.Id == id);
        }
    }
}
