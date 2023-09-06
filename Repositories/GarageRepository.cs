using Microsoft.EntityFrameworkCore;
using RestAPI_Work.Data;
using RestAPI_Work.Models.DBModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace RestAPI_Work.Repositories
{
    public class GarageRepository : IGarageRepository
    {
        private readonly ApplicationDbContext _context;

        public GarageRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Garage>> GetAllAsync()
        {
            return await _context.Garages.Include(g => g.Machines).ToListAsync();
        }

        public async Task<Garage?> GetByIdAsync(int id)
        {
            return await _context.Garages.Include(g => g.Machines).FirstOrDefaultAsync(g => g.GarageId == id);
        }

        public async Task AddAsync(Garage garage)
        {
            _context.Garages.Add(garage);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Garage garage)
        {
            _context.Entry(garage).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var garage = await _context.Garages.FindAsync(id);
            _context.Garages.Remove(garage);
            await _context.SaveChangesAsync(); 
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Garages.AnyAsync(e => e.GarageId == id);
        }
    }
}
