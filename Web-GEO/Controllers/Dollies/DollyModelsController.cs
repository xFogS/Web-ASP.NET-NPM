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
    public class DollyModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DollyModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DollyModels
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.DollyModels
                .Include(d => d.ColorModel)
                .Include(d => d.ImageModel)
                .Include(d => d.StyleModel);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: DollyModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dollyModel = await _context.DollyModels
                .Include(d => d.ColorModel)
                .Include(d => d.ImageModel)
                .Include(d => d.StyleModel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dollyModel == null)
            {
                return NotFound();
            }

            return View(dollyModel);
        }

        // GET: DollyModels/Create
        public IActionResult Create()
        {
            ViewData["ColorId"] = new SelectList(_context.DollyColorModels, "Id", "Name");
            ViewData["ImageId"] = new SelectList(_context.ImageModels, "Id", "URL");
            ViewData["StyleId"] = new SelectList(_context.StyleModels, "Id", "Name");
            return View();
        }

        // POST: DollyModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,ColorId,StyleId,ImageId")] DollyModel dollyModel, IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                if (ModelState.IsValid)
                {
                    _context.Add(dollyModel);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }

            ViewData["ColorId"] = new SelectList(_context.DollyColorModels, "Id", "Name", dollyModel.ColorId);
            ViewData["ImageId"] = new SelectList(_context.ImageModels, "Id", "URL", dollyModel.ImageId);
            ViewData["StyleId"] = new SelectList(_context.StyleModels, "Id", "Name", dollyModel.StyleId);
            return View(dollyModel);
        }

        // GET: DollyModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dollyModel = await _context.DollyModels.FindAsync(id);
            if (dollyModel == null)
            {
                return NotFound();
            }
            ViewData["ColorId"] = new SelectList(_context.DollyColorModels, "Id", "Name", dollyModel.ColorId);
            ViewData["ImageId"] = new SelectList(_context.ImageModels, "Id", "URL", dollyModel.ImageId);
            ViewData["StyleId"] = new SelectList(_context.StyleModels, "Id", "Name", dollyModel.StyleId);
            return View(dollyModel);
        }

        // POST: DollyModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,ColorId,StyleId,ImageId")] DollyModel dollyModel)
        {
            if (id != dollyModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dollyModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DollyModelExists(dollyModel.Id))
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
            ViewData["ColorId"] = new SelectList(_context.DollyColorModels, "Id", "Name", dollyModel.ColorId);
            ViewData["ImageId"] = new SelectList(_context.ImageModels, "Id", "URL", dollyModel.ImageId);
            ViewData["StyleId"] = new SelectList(_context.StyleModels, "Id", "Name", dollyModel.StyleId);
            return View(dollyModel);
        }

        // GET: DollyModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dollyModel = await _context.DollyModels
                .Include(d => d.ColorModel)
                .Include(d => d.ImageModel)
                .Include(d => d.StyleModel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dollyModel == null)
            {
                return NotFound();
            }

            return View(dollyModel);
        }

        // POST: DollyModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dollyModel = await _context.DollyModels.FindAsync(id);
            if (dollyModel != null)
            {
                _context.DollyModels.Remove(dollyModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DollyModelExists(int id)
        {
            return _context.DollyModels.Any(e => e.Id == id);
        }
    }
}
