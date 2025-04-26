using TravelAgency.DAL.Context.Contracts;
using Microsoft.EntityFrameworkCore;
using TravelAgency.DAL.Entities;

namespace TravelAgency.DAL.Context
{
    public class TravelAgencyDbContext : DbContext, IDbReader, IDbWriter, IUnitOfWork
    {
        public DbSet<Ticket> Tickets { get; set; }

        public TravelAgencyDbContext(DbContextOptions<TravelAgencyDbContext> options)
            : base(options)
        {
            //Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=agency;Username=postgres;Password=postgres");
        }

        IQueryable<TEntity> IDbReader.Read<TEntity>()
            => base.Set<TEntity>()
            .AsNoTracking().AsQueryable();

        void IDbWriter.Create<TEntity>(TEntity entity)
            => base.Entry(entity).State = EntityState.Added;

        void IDbWriter.Update<TEntity>(TEntity entity)
            => base.Entry(entity).State = EntityState.Modified;

        void IDbWriter.Delete<TEntity>(TEntity entity)
            => base.Entry(entity).State = EntityState.Deleted;
    }
}
