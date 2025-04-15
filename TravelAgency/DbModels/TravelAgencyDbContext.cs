using Microsoft.EntityFrameworkCore;

namespace TravelAgency.DbModels
{
    public class TravelAgencyDbContext : DbContext
    {
        public DbSet<Ticket> Tickets { get; set; }

        public TravelAgencyDbContext(DbContextOptions<TravelAgencyDbContext> options)
            : base(options)
        {
            //Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=agency;Username=postgres;Password=postgres");
        }
    }
}
