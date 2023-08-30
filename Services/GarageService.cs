using RestAPI_Work.Data;
using RestAPI_Work.Models.DBModels;
using RestAPI_Work.Requests;
using RestAPI_Work.Responses;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RestAPI_Work.Services
{
    public class GarageService : IGarageService
    {
        private readonly ApplicationDbContext _context;

        public GarageService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GarageResponse>> GetAllAsync()
        {
            return await _context.Garages
                .Select(g => new GarageResponse { GarageId = g.GarageId, Name = g.Name })
                .ToListAsync();
        }

        public async Task<GarageResponse> GetByIdAsync(int id)
        {
            var garage = await _context.Garages.FindAsync(id);
            if (garage == null)
            {
                return null;
            }
            return new GarageResponse { GarageId = garage.GarageId, Name = garage.Name };
        }

        public async Task<GarageResponse> CreateAsync(CreateGarageRequest garageRequest)
        {
            var newGarage = new Garage { Name = garageRequest.Name };
            _context.Garages.Add(newGarage);
            await _context.SaveChangesAsync();
            return new GarageResponse { GarageId = newGarage.GarageId, Name = newGarage.Name };
        }

        public async Task<bool> UpdateAsync(int id, UpdateGarageRequest garageRequest)
        {
            var existingGarage = await _context.Garages.FindAsync(id);
            if (existingGarage == null)
            {
                return false;
            }
            existingGarage.Name = garageRequest.Name;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var garage = await _context.Garages.FindAsync(id);
            if (garage == null)
            {
                return false;
            }
            _context.Garages.Remove(garage);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
