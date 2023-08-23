using RestAPI_Work.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestAPI_Work.Services
{
    public interface IGarageService
    {
        Task<IEnumerable<Garage>> GetAllGaragesAsync();
        Task<Garage> GetGarageByIdAsync(int id);
        Task AddGarageAsync(Garage garage);
        Task UpdateGarageAsync(int id, Garage garage);
        Task DeleteGarageAsync(int id);
        Task<bool> GarageExistsAsync(int id);
    }
}
