using Microsoft.EntityFrameworkCore;
using RestAPI_Work.Models.DBModels;


namespace RestAPI_Work.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Garage> Garages { get; set; }
        public DbSet<Machine> Machines { get; set; }
    }
}
