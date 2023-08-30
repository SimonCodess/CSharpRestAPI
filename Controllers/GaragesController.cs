using Microsoft.AspNetCore.Mvc;
using RestAPI_Work.Requests;
using RestAPI_Work.Responses;
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
        public async Task<ActionResult<IEnumerable<GarageResponse>>> GetGarages()
        {
            return Ok(await _garageService.GetAllAsync());
        }

        // GET: api/Garages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GarageResponse>> GetGarage(int id)
        {
            var garage = await _garageService.GetByIdAsync(id);

            if (garage == null)
            {
                return NotFound();
            }

            return garage;
        }

        // PUT: api/Garages/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGarage(int id, UpdateGarageRequest garageRequest)
        {
            if (!await _garageService.UpdateAsync(id, garageRequest))
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/Garages
        [HttpPost]
        public async Task<ActionResult<GarageResponse>> PostGarage(CreateGarageRequest garageRequest)
        {
            var createdGarage = await _garageService.CreateAsync(garageRequest);
            return CreatedAtAction(nameof(GetGarage), new { id = createdGarage.GarageId }, createdGarage);
        }

        // DELETE: api/Garages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGarage(int id)
        {
            if (!await _garageService.DeleteAsync(id))
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
