using Microsoft.EntityFrameworkCore;
using RestAPI_Work.Data;
using RestAPI_Work.Models.DBModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestAPI_Work.Repositories
{
    public class MachineRepository : IMachineRepository
    {
        private readonly ApplicationDbContext _context;

        public MachineRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Machine>> GetAllMachinesAsync()
        {
            return await _context.Machines.ToListAsync();
        }

        public async Task<Machine> GetMachineByIdAsync(int id)
        {
            return await _context.Machines.FindAsync(id);
        }

        public async Task AddMachineAsync(Machine machine)
        {
            _context.Machines.Add(machine);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateMachineAsync(int id, Machine machine)
        {
            _context.Entry(machine).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMachineAsync(int id)
        {
            var machine = await _context.Machines.FindAsync(id);
            _context.Machines.Remove(machine);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> MachineExistsAsync(int id)
        {
            return await _context.Machines.AnyAsync(e => e.MachineId == id);
        }
    }
}
