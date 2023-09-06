using RestAPI_Work.Models.DBModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestAPI_Work.Repositories
{
    public interface IMachineRepository
    {
        Task<IEnumerable<Machine>> GetAllMachinesAsync();
        Task<Machine> GetMachineByIdAsync(int id);
        Task AddMachineAsync(Machine machine);
        Task UpdateMachineAsync(int id, Machine machine);
        Task DeleteMachineAsync(int id);
        Task<bool> MachineExistsAsync(int id);
    }
}
