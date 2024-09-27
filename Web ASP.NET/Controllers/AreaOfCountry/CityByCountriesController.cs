using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Web_ASP.NET.Data;
using Web_ASP.NET.Models.Enteties;

namespace Web_ASP.NET.Controllers.AreaOfCountry
{
    public class CityByCountriesController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CityByCountriesController(ApplicationDbContext context) { _context = context; }

        public IActionResult Index(int? countryId, int? areaId, int? cityId)
        {
            var countries = _context.Countries.ToList();
            ViewBag.Countries = new SelectList(countries, "Id", "Name", countryId);
            
            if (countryId != null)
            {
                var areas = _context.Areas
                    .Where(a => a.CountryId == countryId)
                    .ToList();
                ViewBag.Areas = new SelectList(areas, "Id", "Name");
            }

            if (areaId != null)
            {
                var cities = _context.Cities.Where(c => c.AreaId == areaId)
                    .ToList();

                ViewBag.Cities = new SelectList(cities, "Id", "Name");
            }
            return View();
        }
    }
}
