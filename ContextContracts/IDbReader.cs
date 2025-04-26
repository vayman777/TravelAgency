namespace TravelAgency.DAL.Context.Contracts
{
    public interface IDbReader
    {
        IQueryable<TEntity> Read<TEntity>() where TEntity : class;
    }
}
