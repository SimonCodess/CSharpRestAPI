
namespace RestAPI_Work.Models.DBModels
{
    public class Machine
    {
        public int MachineId { get; set; }
        public string Name { get; set; } = "";
        public int GarageId { get; set; }  // Foreign Key to Garage entity
        public Garage? Garage { get; set; }
    }
}
