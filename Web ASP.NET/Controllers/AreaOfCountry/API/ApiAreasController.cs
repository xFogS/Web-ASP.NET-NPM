using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_ASP.NET.Data;
using Web_ASP.NET.Models.Enteties;

namespace Web_ASP.NET.Controllers.AreaOfCountry.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiAreasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ApiAreasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ApiAreas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Area>>> GetAreas()
        {
            return await _context.Areas.ToListAsync();
        }

        // GET: api/ApiAreas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Area>>> GetArea(int id)
        {
            var area = await _context.Areas
                .Where(a => a.CountryId == id)
                .ToListAsync();

            if (area == null)
            {
                return NotFound();
            }

            return area;
        }

        // PUT: api/ApiAreas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArea(int id, Area area)
        {
            if (id != area.Id)
            {
                return BadRequest();
            }

            _context.Entry(area).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AreaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ApiAreas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Area>> PostArea(Area area)
        {
            _context.Areas.Add(area);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetArea", new { id = area.Id }, area);
        }

        // DELETE: api/ApiAreas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArea(int id)
        {
            var area = await _context.Areas.FindAsync(id);
            if (area == null)
            {
                return NotFound();
            }

            _context.Areas.Remove(area);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AreaExists(int id)
        {
            return _context.Areas.Any(e => e.Id == id);
        }
    }
}
