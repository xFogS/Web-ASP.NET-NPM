using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Web_ASP.NET.Data;
using Web_ASP.NET.Models.Enteties;

namespace Web_ASP.NET.Controllers
{
    public class AreaRegionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AreaRegionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AreaRegions
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.AreaRegions.Include(a => a.Area).Include(a => a.Region);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: AreaRegions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var areaRegions = await _context.AreaRegions
                .Include(a => a.Area)
                .Include(a => a.Region)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (areaRegions == null)
            {
                return NotFound();
            }

            return View(areaRegions);
        }

        // GET: AreaRegions/Create
        public IActionResult Create()
        {
            ViewData["AreaId"] = new SelectList(_context.Areas, "Id", "Name");
            ViewData["RegionId"] = new SelectList(_context.Regions, "Id", "Name");
            return View();
        }

        // POST: AreaRegions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AreaId,RegionId")] AreaRegions areaRegions)
        {
            if (ModelState.IsValid)
            {
                _context.Add(areaRegions);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AreaId"] = new SelectList(_context.Areas, "Id", "Name");
            ViewData["RegionId"] = new SelectList(_context.Regions, "Id", "Name");
            return View(areaRegions);
        }

        // GET: AreaRegions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var areaRegions = await _context.AreaRegions.FindAsync(id);
            if (areaRegions == null)
            {
                return NotFound();
            }
            ViewData["AreaId"] = new SelectList(_context.Areas, "Id", "Name");
            ViewData["RegionId"] = new SelectList(_context.Regions, "Id", "Name");
            return View(areaRegions);
        }

        // POST: AreaRegions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AreaId,RegionId")] AreaRegions areaRegions)
        {
            if (id != areaRegions.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(areaRegions);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AreaRegionsExists(areaRegions.Id))
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
            ViewData["AreaId"] = new SelectList(_context.Areas, "Id", "Name");
            ViewData["RegionId"] = new SelectList(_context.Regions, "Id", "Name");
            return View(areaRegions);
        }

        // GET: AreaRegions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var areaRegions = await _context.AreaRegions
                .Include(a => a.Area)
                .Include(a => a.Region)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (areaRegions == null)
            {
                return NotFound();
            }

            return View(areaRegions);
        }

        // POST: AreaRegions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var areaRegions = await _context.AreaRegions.FindAsync(id);
            if (areaRegions != null)
            {
                _context.AreaRegions.Remove(areaRegions);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AreaRegionsExists(int id)
        {
            return _context.AreaRegions.Any(e => e.Id == id);
        }
    }
}
