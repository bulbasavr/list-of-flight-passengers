using Microsoft.EntityFrameworkCore;

namespace ListOfFlightPassengers.Models
{
    internal class ApplicationContext : DbContext
    {
        public DbSet<Passenger> Passengers { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=passengerslistdb;Trusted_Connection=True;");
        }
    }
}
