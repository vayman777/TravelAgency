using TravelAgency.DAL.Context.Contracts;
using Microsoft.EntityFrameworkCore;
using TravelAgency.DAL.Entities;

namespace TravelAgency.DAL.Context
{
    /// <summary>
    /// Контекст БД
    /// </summary>
    public class TravelAgencyDbContext : DbContext, IDbReader, IDbWriter, IUnitOfWork
    {
        public DbSet<Ticket> Tickets { get; set; }

        public TravelAgencyDbContext(DbContextOptions<TravelAgencyDbContext> options)
            : base(options)
        {
            //Database.EnsureCreated();
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
