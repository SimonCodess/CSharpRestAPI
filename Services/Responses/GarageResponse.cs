namespace RestAPI_Work.Services.Responses
{
    public class GarageResponse
    {
        public int GarageId { get; set; }
        public string? Name { get; set; }
        public ICollection<MachineResponse>? Machines { get; set; }
    }
}
