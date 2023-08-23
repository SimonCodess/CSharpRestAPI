using Microsoft.AspNetCore.Mvc;
using RestAPI_Work.Models;
using RestAPI_Work.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestAPI_Work.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GaragesController : ControllerBase
    {
        private readonly IGarageService _garageService;

        public GaragesController(IGarageService garageService)
        {
            _garageService = garageService;
        }

        // GET: api/Garages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Garage>>> GetGarages()
        {
            return Ok(await _garageService.GetAllGaragesAsync());
        }

        // GET: api/Garages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Garage>> GetGarage(int id)
        {
            var garage = await _garageService.GetGarageByIdAsync(id);

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
            if (id != garage.GarageId || !await _garageService.GarageExistsAsync(id))
            {
                return BadRequest();
            }

            await _garageService.UpdateGarageAsync(id, garage);
            return NoContent();
        }

        // POST: api/Garages
        [HttpPost]
        public async Task<ActionResult<Garage>> PostGarage(Garage garage)
        {
            await _garageService.AddGarageAsync(garage);
            return CreatedAtAction(nameof(GetGarage), new { id = garage.GarageId }, garage);
        }

        // DELETE: api/Garages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGarage(int id)
        {
            if (!await _garageService.GarageExistsAsync(id))
            {
                return NotFound();
            }

            await _garageService.DeleteGarageAsync(id);
            return NoContent();
        }
    }
}
