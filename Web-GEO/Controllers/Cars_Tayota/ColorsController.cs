using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Web_GEO.Data;
using Web_GEO.Models.Cars_Tayota;

namespace Web_GEO.Controllers.Cars_Tayota
{
    public class ColorsController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ColorsController(ApplicationDbContext context) { _context = context; }

        public async Task<IActionResult> Index() { return View(await _context.ColorModels.ToListAsync()); }
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

            //ViewData["ModelId"] = new SelectList(_context.ColorModels, "Id", "Name", model.Id);
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
            ViewData["modelOfTheCar"] = model;
            return View(model);
        }
        public IActionResult Delete() { return View(); }
    }
}
