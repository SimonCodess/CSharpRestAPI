using RestAPI_Work.Models.DBModels;
using RestAPI_Work.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestAPI_Work.Services.Responses;
using RestAPI_Work.Services.Requests;

namespace RestAPI_Work.Services
{
    public class GarageService : IGarageService
    {
        private readonly IGarageRepository _garageRepository;

        public GarageService(IGarageRepository garageRepository)
        {
            _garageRepository = garageRepository;
        }

        public async Task<IEnumerable<GarageResponse>> GetAllAsync()
        {
            var garages = await _garageRepository.GetAllAsync();
            return garages.Select(g => new GarageResponse
            {
                GarageId = g.GarageId,
                Name = g.Name,
                Machines = g.Machines?.Select(m => new MachineResponse
                {
                    MachineId = m.MachineId,
                    Name = m.Name,
                    GarageId = m.GarageId
                }).ToList()
            }).ToList();
        }

        public async Task<GarageResponse> GetByIdAsync(int id)
        {
            var garage = await _garageRepository.GetByIdAsync(id);
            if (garage == null)
            {
                return null;
            }

            return new GarageResponse
            {
                GarageId = garage.GarageId,
                Name = garage.Name,
                Machines = garage.Machines?.Select(m => new MachineResponse
                {
                    MachineId = m.MachineId,
                    Name = m.Name,
                    GarageId = m.GarageId
                }).ToList()
            };
        }

        public async Task<GarageResponse> CreateAsync(CreateGarageRequest garageRequest)
        {
            var newGarage = new Garage { Name = garageRequest.Name };
            await _garageRepository.AddAsync(newGarage);
            return new GarageResponse { GarageId = newGarage.GarageId, Name = newGarage.Name };
        }

        public async Task<bool> UpdateAsync(int id, UpdateGarageRequest garageRequest)
        {
            var existingGarage = await _garageRepository.GetByIdAsync(id);
            if (existingGarage == null)
            {
                return false;
            }
            existingGarage.Name = garageRequest.Name;
            await _garageRepository.UpdateAsync(existingGarage);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var garage = await _garageRepository.GetByIdAsync(id);
            if (garage == null)
            {
                return false;
            }
            await _garageRepository.DeleteAsync(id);
            return true;
        }
    }
}
