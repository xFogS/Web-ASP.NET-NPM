using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Web_ASP.NET.Data;
using Web_ASP.NET.Models.Enteties;

namespace Web_ASP.NET.Controllers.AreaOfCountry
{
    public class CityCityTypeLinksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CityCityTypeLinksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CityCityTypeLinks
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.CityCityTypeLinks.Include(c => c.City).Include(c => c.CityType);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: CityCityTypeLinks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cityCityTypeLink = await _context.CityCityTypeLinks
                .Include(c => c.City)
                .Include(c => c.CityType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cityCityTypeLink == null)
            {
                return NotFound();
            }

            return View(cityCityTypeLink);
        }

        // GET: CityCityTypeLinks/Create
        public IActionResult Create()
        {
            ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Name");
            ViewData["CityTypeId"] = new SelectList(_context.CityTypes, "Id", "Name");
            return View();
        }

        // POST: CityCityTypeLinks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CityId,CityTypeId")] CityCityTypeLink cityCityTypeLink)
        {
            /*if (ModelState.IsValid)
            {*/
            _context.Add(cityCityTypeLink);
            await _context.SaveChangesAsync();
            /*return */
            RedirectToAction(nameof(Index));
            /* }*/
            ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Name", cityCityTypeLink.CityId);
            ViewData["CityTypeId"] = new SelectList(_context.CityTypes, "Id", "Name", cityCityTypeLink.CityTypeId);
            return View(cityCityTypeLink);
        }

        // GET: CityCityTypeLinks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cityCityTypeLink = await _context.CityCityTypeLinks.FindAsync(id);
            if (cityCityTypeLink == null)
            {
                return NotFound();
            }
            ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Name", cityCityTypeLink.CityId);
            ViewData["CityTypeId"] = new SelectList(_context.CityTypes, "Id", "Name", cityCityTypeLink.CityTypeId);
            return View(cityCityTypeLink);
        }

        // POST: CityCityTypeLinks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CityId,CityTypeId")] CityCityTypeLink cityCityTypeLink)
        {
            if (id != cityCityTypeLink.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cityCityTypeLink);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CityCityTypeLinkExists(cityCityTypeLink.Id))
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
            ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Name", cityCityTypeLink.CityId);
            ViewData["CityTypeId"] = new SelectList(_context.CityTypes, "Id", "Name", cityCityTypeLink.CityTypeId);
            return View(cityCityTypeLink);
        }

        // GET: CityCityTypeLinks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cityCityTypeLink = await _context.CityCityTypeLinks
                .Include(c => c.City)
                .Include(c => c.CityType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cityCityTypeLink == null)
            {
                return NotFound();
            }

            return View(cityCityTypeLink);
        }

        // POST: CityCityTypeLinks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cityCityTypeLink = await _context.CityCityTypeLinks.FindAsync(id);
            if (cityCityTypeLink != null)
            {
                _context.CityCityTypeLinks.Remove(cityCityTypeLink);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CityCityTypeLinkExists(int id)
        {
            return _context.CityCityTypeLinks.Any(e => e.Id == id);
        }
    }
}
