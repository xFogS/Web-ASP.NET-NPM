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
    public class ConfigurationColorModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ConfigurationColorModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ConfigurationColorModels
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ConfigurationColorModels
                .Include(c => c.ColorModel)
                .Include(c => c.ConfigurationModel);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ConfigurationColorModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var configurationColorModel = await _context.ConfigurationColorModels
                .Include(c => c.ColorModel)
                .Include(c => c.ConfigurationModel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (configurationColorModel == null)
            {
                return NotFound();
            }

            return View(configurationColorModel);
        }

        // GET: ConfigurationColorModels/Create
        public IActionResult Create()
        {
            ViewData["ColorId"] = new SelectList(_context.ColorModels, "Id", "Name");
            ViewData["ConfigurationId"] = new SelectList(_context.ConfigurationModels, "Id", "Name");
            return View();
        }

        // POST: ConfigurationColorModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ColorId,ConfigurationId")] ConfigurationColorModel configurationColorModel, IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                string directoriesFile = "/storage/colors";
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot" + directoriesFile, file.FileName);
                if (filePath != null && ModelState.IsValid)
                {
                    using (Stream stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                        configurationColorModel.CarImageUrl = $"{directoriesFile}/{file.FileName}";
                    }
                    _context.Add(configurationColorModel);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            ViewData["ColorId"] = new SelectList(_context.ColorModels, "Id", "Name", configurationColorModel.ColorId);
            ViewData["ConfigurationId"] = new SelectList(_context.ConfigurationModels, "Id", "Name", configurationColorModel.ConfigurationId);
            return View(configurationColorModel);
        }

        // GET: ConfigurationColorModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var configurationColorModel = await _context.ConfigurationColorModels.FindAsync(id);
            if (configurationColorModel == null)
            {
                return NotFound();
            }
            ViewData["ColorId"] = new SelectList(_context.ColorModels, "Id", "Name", configurationColorModel.ColorId);
            ViewData["ConfigurationId"] = new SelectList(_context.ConfigurationModels, "Id", "Name", configurationColorModel.ConfigurationId);
            return View(configurationColorModel);
        }

        // POST: ConfigurationColorModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ColorId,ConfigurationId,CarImageUrl")] ConfigurationColorModel configurationColorModel)
        {
            if (id != configurationColorModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(configurationColorModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConfigurationColorModelExists(configurationColorModel.Id))
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
            ViewData["ColorId"] = new SelectList(_context.ColorModels, "Id", "Name", configurationColorModel.ColorId);
            ViewData["ConfigurationId"] = new SelectList(_context.ConfigurationModels, "Id", "Name", configurationColorModel.ConfigurationId);
            return View(configurationColorModel);
        }

        // GET: ConfigurationColorModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var configurationColorModel = await _context.ConfigurationColorModels
                .Include(c => c.ColorModel)
                .Include(c => c.ConfigurationModel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (configurationColorModel == null)
            {
                return NotFound();
            }

            return View(configurationColorModel);
        }

        // POST: ConfigurationColorModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var configurationColorModel = await _context.ConfigurationColorModels.FindAsync(id);
            if (configurationColorModel != null)
            {
                _context.ConfigurationColorModels.Remove(configurationColorModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConfigurationColorModelExists(int id)
        {
            return _context.ConfigurationColorModels.Any(e => e.Id == id);
        }
    }
}
