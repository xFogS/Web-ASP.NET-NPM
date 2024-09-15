using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Web_GEO.Data;
using Web_GEO.Models.Store;

namespace Web_GEO.Controllers.Store
{
    public class VendorController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VendorController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: VendorModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.VendorModels.ToListAsync());
        }

        // GET: VendorModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vendorModel = await _context.VendorModels
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vendorModel == null)
            {
                return NotFound();
            }

            return View(vendorModel);
        }

        // GET: VendorModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VendorModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] VendorModel vendorModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vendorModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vendorModel);
        }

        // GET: VendorModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vendorModel = await _context.VendorModels.FindAsync(id);
            if (vendorModel == null)
            {
                return NotFound();
            }
            return View(vendorModel);
        }

        // POST: VendorModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] VendorModel vendorModel)
        {
            if (id != vendorModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vendorModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VendorModelExists(vendorModel.Id))
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
            return View(vendorModel);
        }

        // GET: VendorModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vendorModel = await _context.VendorModels
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vendorModel == null)
            {
                return NotFound();
            }

            return View(vendorModel);
        }

        // POST: VendorModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vendorModel = await _context.VendorModels.FindAsync(id);
            if (vendorModel != null)
            {
                _context.VendorModels.Remove(vendorModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VendorModelExists(int id)
        {
            return _context.VendorModels.Any(e => e.Id == id);
        }
    }
}
