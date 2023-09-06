using RestAPI_Work.Models.DBModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestAPI_Work.Repositories
{
    public interface IGarageRepository
    {
        Task<IEnumerable<Garage>> GetAllAsync();
        Task<Garage?> GetByIdAsync(int id);
        Task AddAsync(Garage garage);
        Task UpdateAsync(Garage garage);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}