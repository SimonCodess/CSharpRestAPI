using RestAPI_Work.Models;
using RestAPI_Work.Repositories;

namespace RestAPI_Work.Services
{
    public class GarageService : IGarageService
    {
        private readonly IGarageRepository _repository;

        public GarageService(IGarageRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Garage>> GetAllGaragesAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Garage> GetGarageByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddGarageAsync(Garage garage)
        {
            await _repository.AddAsync(garage);
        }

        public async Task UpdateGarageAsync(int id, Garage garage)
        {
            await _repository.UpdateAsync(garage);
        }

        public async Task DeleteGarageAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<bool> GarageExistsAsync(int id)
        {
            return await _repository.ExistsAsync(id);
        }
    }
}
