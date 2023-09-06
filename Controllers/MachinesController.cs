using Microsoft.AspNetCore.Mvc;
using RestAPI_Work.Services;
using RestAPI_Work.Services.Requests;
using RestAPI_Work.Services.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestAPI_Work.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MachinesController : ControllerBase
    {
        private readonly IMachineService _machineService;

        public MachinesController(IMachineService machineService)
        {
            _machineService = machineService;
        }

        // GET: api/Machines
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MachineResponse>>> GetMachines()
        {
            return Ok(await _machineService.GetAllMachinesAsync());
        }

        // GET: api/Machines/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MachineResponse>> GetMachine(int id)
        {
            var machine = await _machineService.GetMachineByIdAsync(id);

            if (machine == null)
            {
                return NotFound();
            }

            return machine;
        }

        // PUT: api/Machines/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMachine(int id, UpdateMachineRequest machineRequest)
        {
            if (!await _machineService.MachineExistsAsync(id))
            {
                return NotFound();
            }

            await _machineService.UpdateMachineAsync(id, machineRequest);
            return NoContent();
        }

        // POST: api/Machines
        [HttpPost]
        public async Task<ActionResult<MachineResponse>> PostMachine(CreateMachineRequest machineRequest)
        {
            var machine = await _machineService.AddMachineAsync(machineRequest);
            return CreatedAtAction(nameof(GetMachine), new { id = machine.MachineId }, machine);
        }

        // DELETE: api/Machines/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMachine(int id)
        {
            if (!await _machineService.MachineExistsAsync(id))
            {
                return NotFound();
            }

            await _machineService.DeleteMachineAsync(id);
            return NoContent();
        }
    }
}
