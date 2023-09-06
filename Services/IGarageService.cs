using Microsoft.AspNetCore.Mvc;
using RestAPI_Work.Services.Requests;
using RestAPI_Work.Services.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestAPI_Work.Services
{
    public interface IGarageService
    {
        Task<IEnumerable<GarageResponse>> GetAllAsync();
        Task<GarageResponse> GetByIdAsync(int id);
        Task<GarageResponse> CreateAsync(CreateGarageRequest garageRequest);
        Task<bool> UpdateAsync(int id, UpdateGarageRequest garageRequest);
        Task<bool> DeleteAsync(int id);
    }
}
