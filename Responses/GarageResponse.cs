namespace RestAPI_Work.Responses
{
    public class GarageResponse
    {
        public int GarageId { get; set; }
        public string? Name { get; set; }
        public ICollection<MachineResponse>? Machines { get; set; }
    }
}
