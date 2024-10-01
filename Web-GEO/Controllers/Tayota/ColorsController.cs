using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Web_GEO.Data;
using Web_GEO.Models.Cars.Tayota;
using Web_GEO.Models.ViewModels;

namespace Web_GEO.Controllers.Tayota
{
    public class ColorsController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ColorsController(ApplicationDbContext context) { _context = context; }

        public async Task<IActionResult> Index(int pageNumber = 1, int pageSize = 2, string sortColumn = "Name", string sortDirection = "asc")
        {
            var query = _context.ColorModels.AsQueryable();
            query = sortColumn switch
            {
                "Id" => sortDirection == "asc" ? query.OrderBy(c => c.Id) : query.OrderByDescending(c => c.Id),
                "Name" => sortDirection == "asc" ? query.OrderBy(c => c.Name) : query.OrderByDescending(c => c.Name),
                _ => sortDirection == "asc" ? query.OrderBy(c => c.Name) : query.OrderByDescending(c => c.Name),
            };
            var totalItems = await query.CountAsync();
            var colors = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            ViewData["Paginate"] = new PaginateViewModel
            {
                // pagination
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalItems = totalItems,
                // sort
                SortColumn = sortColumn,
                SortDirection = sortDirection,
                Columns = new List<string>(["Id", "Name"])
            };
            return View(colors);
        }
        public IActionResult Create() { return View(); }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id", "Name", "RGB", "Code")] ColorModel model, IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                string directoryOfFile = "/storage/colors";
                //1. folder , 2.subfolder, 3. filename
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot" + directoryOfFile, file.FileName);
                using (Stream stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                    model.URL = $"{directoryOfFile}/{file.FileName}";
                }
                //append check isvalid
            }
            _context.Add(model);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Edit(int? Id)
        {
            if (Id == null) { NotFound(); }
            var model = await _context.ColorModels
                .FindAsync(Id);
            if (model == null) { NotFound(); }
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int Id, [Bind("Id", "Name", "URL", "RGB", "Code")] ColorModel model)
        {
            if (Id == model.Id && ModelState.IsValid)
            {
                _context.ColorModels.Update(model);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ModelId"] = new SelectList(_context.ColorModels, "Id", "Name");
            return View(model);
        }
        public async Task<IActionResult> Details(int? Id)
        {
            if (Id == null) { NotFound(); }
            var model = await _context.ColorModels
                .FirstAsync(x => x.Id == Id);
            if (model == null) { NotFound(); }
            //ViewData["modelOfTheCar"] = model;
            return View(model);
        }
        public async Task<IActionResult> Delete(int? Id)
        {
            if (Id == null) { NotFound(); }
            var model = await _context.ColorModels
                .FirstOrDefaultAsync(x => x.Id == Id);
            if (model == null) { NotFound(); }
            return View(model);
        }
        //get colors/delete/id
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfident(int Id)
        {
            var model = await _context.ColorModels
                .FindAsync(Id);
            if (model != null && ModelState.IsValid)
            {
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", $"{model.URL}");
                _context.ColorModels.Remove(model);
                //delete file from model.url - choice developer
                /*if (System.IO.File.Exists("wwwroot" + filePath))
                    System.IO.File.Delete("wwwroot" + filePath);*/
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
