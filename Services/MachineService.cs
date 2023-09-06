using RestAPI_Work.Models.DBModels;
using RestAPI_Work.Repositories;
using RestAPI_Work.Services.Requests;
using RestAPI_Work.Services.Responses;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPI_Work.Services
{
    public class MachineService : IMachineService
    {
        private readonly IMachineRepository _machineRepository;

        public MachineService(IMachineRepository machineRepository)
        {
            _machineRepository = machineRepository;
        }

        public async Task<IEnumerable<MachineResponse>> GetAllMachinesAsync()
        {
            var machines = await _machineRepository.GetAllMachinesAsync();
            return machines.Select(m => new MachineResponse
            {
                MachineId = m.MachineId,
                Name = m.Name,
                GarageId = m.GarageId
            });
        }

        public async Task<MachineResponse> GetMachineByIdAsync(int id)
        {
            var machine = await _machineRepository.GetMachineByIdAsync(id);
            if (machine == null)
            {
                return null;
            }

            return new MachineResponse
            {
                MachineId = machine.MachineId,
                Name = machine.Name,
                GarageId = machine.GarageId
            };
        }

        public async Task<MachineResponse> AddMachineAsync(CreateMachineRequest machineRequest)
        {
            var machine = new Machine
            {
                Name = machineRequest.Name,
                GarageId = machineRequest.GarageId
            };

            await _machineRepository.AddMachineAsync(machine);

            return new MachineResponse
            {
                MachineId = machine.MachineId,
                Name = machine.Name,
                GarageId = machine.GarageId
            };
        }

        public async Task UpdateMachineAsync(int id, UpdateMachineRequest machineRequest)
        {
            var existingMachine = await _machineRepository.GetMachineByIdAsync(id);
            if (existingMachine == null)
            {
                return;
            }

            existingMachine.Name = machineRequest.Name;
            existingMachine.GarageId = machineRequest.GarageId;

            await _machineRepository.UpdateMachineAsync(id, existingMachine);
        }

        public async Task DeleteMachineAsync(int id)
        {
            await _machineRepository.DeleteMachineAsync(id);
        }

        public async Task<bool> MachineExistsAsync(int id)
        {
            return await _machineRepository.MachineExistsAsync(id);
        }
    }
}
