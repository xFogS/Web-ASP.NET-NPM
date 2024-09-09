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
    public class StyleModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StyleModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: StyleModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.StyleModels.ToListAsync());
        }

        // GET: StyleModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var styleModel = await _context.StyleModels
                .FirstOrDefaultAsync(m => m.Id == id);
            if (styleModel == null)
            {
                return NotFound();
            }

            return View(styleModel);
        }

        // GET: StyleModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StyleModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] StyleModel styleModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(styleModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(styleModel);
        }

        // GET: StyleModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var styleModel = await _context.StyleModels.FindAsync(id);
            if (styleModel == null)
            {
                return NotFound();
            }
            return View(styleModel);
        }

        // POST: StyleModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] StyleModel styleModel)
        {
            if (id != styleModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(styleModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StyleModelExists(styleModel.Id))
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
            return View(styleModel);
        }

        // GET: StyleModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var styleModel = await _context.StyleModels
                .FirstOrDefaultAsync(m => m.Id == id);
            if (styleModel == null)
            {
                return NotFound();
            }

            return View(styleModel);
        }

        // POST: StyleModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var styleModel = await _context.StyleModels.FindAsync(id);
            if (styleModel != null)
            {
                _context.StyleModels.Remove(styleModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StyleModelExists(int id)
        {
            return _context.StyleModels.Any(e => e.Id == id);
        }
    }
}
