using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Web_GEO.Data;
using Web_GEO.Models.Dolly;

namespace Web_GEO.Controllers.Dollies
{
    public class ColorModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ColorModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ColorModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.DollyColorModels.ToListAsync());
        }

        // GET: ColorModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var colorModel = await _context.DollyColorModels
                .FirstOrDefaultAsync(m => m.Id == id);
            if (colorModel == null)
            {
                return NotFound();
            }

            return View(colorModel);
        }

        // GET: ColorModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ColorModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] ColorModel colorModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(colorModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(colorModel);
        }

        // GET: ColorModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var colorModel = await _context.DollyColorModels.FindAsync(id);
            if (colorModel == null)
            {
                return NotFound();
            }
            return View(colorModel);
        }

        // POST: ColorModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] ColorModel colorModel)
        {
            if (id != colorModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(colorModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ColorModelExists(colorModel.Id))
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
            return View(colorModel);
        }

        // GET: ColorModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var colorModel = await _context.DollyColorModels
                .FirstOrDefaultAsync(m => m.Id == id);
            if (colorModel == null)
            {
                return NotFound();
            }

            return View(colorModel);
        }

        // POST: ColorModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var colorModel = await _context.DollyColorModels.FindAsync(id);
            if (colorModel != null)
            {
                _context.DollyColorModels.Remove(colorModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ColorModelExists(int id)
        {
            return _context.DollyColorModels.Any(e => e.Id == id);
        }
    }
}
