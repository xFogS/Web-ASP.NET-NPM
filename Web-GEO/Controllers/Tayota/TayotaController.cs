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
    public class TayotaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TayotaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Tayota
        public async Task<IActionResult> Index()
        {
            return View(await _context.TayotaModels.ToListAsync());
        }

        // GET: Tayota/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tayotaModel = await _context.TayotaModels
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tayotaModel == null)
            {
                return NotFound();
            }

            return View(tayotaModel);
        }

        // GET: Tayota/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tayota/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] TayotaModel tayotaModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tayotaModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tayotaModel);
        }

        // GET: Tayota/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tayotaModel = await _context.TayotaModels.FindAsync(id);
            if (tayotaModel == null)
            {
                return NotFound();
            }
            return View(tayotaModel);
        }

        // POST: Tayota/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] TayotaModel tayotaModel)
        {
            if (id != tayotaModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tayotaModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TayotaModelExists(tayotaModel.Id))
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
            return View(tayotaModel);
        }

        // GET: Tayota/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tayotaModel = await _context.TayotaModels
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tayotaModel == null)
            {
                return NotFound();
            }

            return View(tayotaModel);
        }

        // POST: Tayota/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tayotaModel = await _context.TayotaModels.FindAsync(id);
            if (tayotaModel != null)
            {
                _context.TayotaModels.Remove(tayotaModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TayotaModelExists(int id)
        {
            return _context.TayotaModels.Any(e => e.Id == id);
        }
    }
}
