using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Web_Testing_etc.Data;
using Web_Testing_etc.Models.Cars;

namespace Web_Testing_etc.Controllers.Cars
{
    public class ColorController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ColorController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Color
        public async Task<IActionResult> Index(int pageNumber = 1, int pageSize = 2, string sortColumn = "Name_asc", string sortDirection = "ascending")
        {
            /*ViewData["sortColumnDirectionName"] = */

            var nameSortParam = string.IsNullOrEmpty(sortColumn) ? "Name_desc" : "";
            var codeSortParam = sortColumn == "Code_asc" ? "Code_desc" : "Code_asc";
            
            var query = _context.ColorsModel.AsQueryable();
            int totalItems = await query.CountAsync();
            query = sortColumn switch
            {
                "Name_asc" => sortDirection == "ascending" ? query.OrderBy(n => n.Name) : query.OrderByDescending(n => n.Name),
                "Code_asc" => sortDirection == "ascending" ? query.OrderBy(n => n.Code) : query.OrderByDescending(n => n.Code),
                _ => sortDirection == "ascending" ? query.OrderBy(n => n.Name) : query.OrderByDescending(n => n.Name),
            };
            var colors = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();


            //Create a model view and bring it to view
            var viewModel = new ColorsPaginationViewModel
            {
                Colors = colors,
                Pagination = new PaginationViewModel()
                {
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    TotalItems = totalItems,
                    HasPrevPage = pageNumber > 1,
                    HasNextPage = pageNumber < (int)Math.Ceiling(totalItems / (double)pageSize)
                },
                CurrentSort = sortDirection,
                NameSortParam = nameSortParam,
                CodeSortParam = codeSortParam,
            };

            return View(viewModel);
        }

        // GET: Color/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var colorModel = await _context.ColorsModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (colorModel == null)
            {
                return NotFound();
            }

            return View(colorModel);
        }

        // GET: Color/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Color/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,RGB,Code")] ColorModel colorModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(colorModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(colorModel);
        }

        // GET: Color/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var colorModel = await _context.ColorsModel.FindAsync(id);
            if (colorModel == null)
            {
                return NotFound();
            }
            return View(colorModel);
        }

        // POST: Color/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,RGB,Code")] ColorModel colorModel)
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

        // GET: Color/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var colorModel = await _context.ColorsModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (colorModel == null)
            {
                return NotFound();
            }

            return View(colorModel);
        }

        // POST: Color/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var colorModel = await _context.ColorsModel.FindAsync(id);
            if (colorModel != null)
            {
                _context.ColorsModel.Remove(colorModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ColorModelExists(int id)
        {
            return _context.ColorsModel.Any(e => e.Id == id);
        }
    }
}
