namespace RestAPI_Work.Services.Requests
{
    public class CreateMachineRequest
    {
        public string Name { get; set; } = "";
        public int GarageId { get; set; }
    }
}