using System.Collections.Generic;
using System.Reflection.PortableExecutable;

namespace RestAPI_Work.Models
{
    public class Garage
    {
        public int GarageId { get; set; }
        public string Name { get; set; } = "";
        public ICollection<Machine>? Machines { get; set; }
    }
}
