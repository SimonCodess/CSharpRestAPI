using RestAPI_Work.Requests;
using RestAPI_Work.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestAPI_Work.Services
{
    public interface IMachineService
    {
        Task<IEnumerable<MachineResponse>> GetAllMachinesAsync();
        Task<MachineResponse> GetMachineByIdAsync(int id);
        Task<MachineResponse> AddMachineAsync(CreateMachineRequest machineRequest);
        Task UpdateMachineAsync(int id, UpdateMachineRequest machineRequest);
        Task DeleteMachineAsync(int id);
        Task<bool> MachineExistsAsync(int id);
    }
}
