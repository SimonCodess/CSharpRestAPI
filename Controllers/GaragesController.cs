using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestAPI_Work.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPI_Work.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GaragesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GaragesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Garages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Garage>>> GetGarages()
        {
            return await _context.Garages.Include(g => g.Machines).ToListAsync();
        }

        // GET: api/Garages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Garage>> GetGarage(int id)
        {
            var garage = await _context.Garages
                .Include(g => g.Machines)  
                .FirstOrDefaultAsync(g => g.GarageId == id);

            if (garage == null)
            {
                return NotFound();
            }

            return garage;
        }

        // PUT: api/Garages/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGarage(int id, Garage garage)
        {
            if (id != garage.GarageId)
            {
                return BadRequest();
            }

            _context.Entry(garage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GarageExists(id))
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

        // POST: api/Garages
        [HttpPost]
        public async Task<ActionResult<Garage>> PostGarage(Garage garage)
        {
            _context.Garages.Add(garage);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetGarage), new { id = garage.GarageId }, garage);
        }

        // DELETE: api/Garages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGarage(int id)
        {
            var garage = await _context.Garages.FindAsync(id);
            if (garage == null)
            {
                return NotFound();
            }

            _context.Garages.Remove(garage);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GarageExists(int id)
        {
            return _context.Garages.Any(e => e.GarageId == id);
        }
    }
}