using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Web_GEO.Data;

namespace Web_GEO.Controllers.Tayota
{
    public class CarByColorController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CarByColorController(ApplicationDbContext context) { _context = context; }
        public async Task<IActionResult> Index(int? modelId = null, int? configurationId = null, int? colorId = null)
        {
            if(modelId == null) { modelId = 1; configurationId = 1; colorId = 11; } //11 default white

            ViewBag.models = new SelectList(await _context.TayotaModels.ToListAsync(), "Id", "Name", modelId);
            if (modelId != null)
            {
                var configuration = await _context.ConfigurationModels
                    .Where(c => c.ModelId == modelId)
                    .ToListAsync();
                ViewBag.configurations = new SelectList(configuration, "Id", "Name", configurationId);
            }
            
            if (configurationId != null)
            {
                var colors = await _context.ConfigurationColorModels
                    .Include(c => c.ColorModel)
                    .Where(c => c.ConfigurationId == configurationId)
                    .ToListAsync();
                ViewBag.colors = new SelectList(colors, "Id", "ColorModel.Name", colorId);
            }

            if(colorId != null)
            {
                var image = await _context.ConfigurationColorModels
                    .Where(c => c.ConfigurationId == configurationId)
                    .FirstOrDefaultAsync(c => c.ColorId == colorId);
                if (image != null)
                {
                    ViewBag.image = image.CarImageUrl;
                }
                else
                {
                    ViewBag.image = "/storage/colors/unknown.png";
                }
            }
            return View();
        }
    }
}
