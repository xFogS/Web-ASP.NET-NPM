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
    public class ActionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ActionController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Action
        public async Task<IActionResult> Index()
        {
            return View(await _context.ActionModels.ToListAsync());
        }

        // GET: Action/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actionModel = await _context.ActionModels
                .FirstOrDefaultAsync(m => m.Id == id);
            if (actionModel == null)
            {
                return NotFound();
            }

            return View(actionModel);
        }

        // GET: Action/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Action/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EndTime,DiscountCount,DiscountPercentage")] ActionModel actionModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(actionModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(actionModel);
        }

        // GET: Action/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actionModel = await _context.ActionModels.FindAsync(id);
            if (actionModel == null)
            {
                return NotFound();
            }
            return View(actionModel);
        }

        // POST: Action/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EndTime,DiscountCount,DiscountPercentage")] ActionModel actionModel)
        {
            if (id != actionModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(actionModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActionModelExists(actionModel.Id))
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
            return View(actionModel);
        }

        // GET: Action/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actionModel = await _context.ActionModels
                .FirstOrDefaultAsync(m => m.Id == id);
            if (actionModel == null)
            {
                return NotFound();
            }

            return View(actionModel);
        }

        // POST: Action/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var actionModel = await _context.ActionModels.FindAsync(id);
            if (actionModel != null)
            {
                _context.ActionModels.Remove(actionModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ActionModelExists(int id)
        {
            return _context.ActionModels.Any(e => e.Id == id);
        }
    }
}
