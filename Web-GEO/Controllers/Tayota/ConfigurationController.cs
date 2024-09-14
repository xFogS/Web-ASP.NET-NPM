using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Web_GEO.Data;
using Web_GEO.Models.Cars.Tayota;

namespace Web_GEO.Controllers.Tayota
{
    public class ConfigurationController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ConfigurationController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Configuration
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ConfigurationModels
                .Include(c => c.TayotaModel);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Configuration/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var configurationModel = await _context.ConfigurationModels
                .Include(c => c.TayotaModel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (configurationModel == null)
            {
                return NotFound();
            }

            return View(configurationModel);
        }

        // GET: Configuration/Create
        public IActionResult Create()
        {
            ViewData["ModelId"] = new SelectList(_context.TayotaModels, "Id", "Name");
            return View();
        }

        // POST: Configuration/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,ModelId")] ConfigurationModel configurationModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(configurationModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ModelId"] = new SelectList(_context.TayotaModels, "Id", "Name", configurationModel.ModelId);
            return View(configurationModel);
        }

        // GET: Configuration/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var configurationModel = await _context.ConfigurationModels.FindAsync(id);
            if (configurationModel == null)
            {
                return NotFound();
            }
            ViewData["ModelId"] = new SelectList(_context.TayotaModels, "Id", "Name", configurationModel.ModelId);
            return View(configurationModel);
        }

        // POST: Configuration/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,ModelId")] ConfigurationModel configurationModel)
        {
            if (id != configurationModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(configurationModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConfigurationModelExists(configurationModel.Id))
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
            ViewData["ModelId"] = new SelectList(_context.TayotaModels, "Id", "Name", configurationModel.ModelId);
            return View(configurationModel);
        }

        // GET: Configuration/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var configurationModel = await _context.ConfigurationModels
                .Include(c => c.TayotaModel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (configurationModel == null)
            {
                return NotFound();
            }

            return View(configurationModel);
        }

        // POST: Configuration/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var configurationModel = await _context.ConfigurationModels.FindAsync(id);
            if (configurationModel != null)
            {
                _context.ConfigurationModels.Remove(configurationModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConfigurationModelExists(int id)
        {
            return _context.ConfigurationModels.Any(e => e.Id == id);
        }
    }
}
