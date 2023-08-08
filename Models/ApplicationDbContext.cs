using Microsoft.EntityFrameworkCore;


namespace RestAPI_Work.Models
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
