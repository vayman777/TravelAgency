namespace TravelAgency.DAL.Context.Contracts
{ 
    public interface IDbWriter
    {
        void Create<TEntity>(TEntity entity) where TEntity : class;

        void Delete<TEntity>(TEntity entity) where TEntity : class;

        void Update<TEntity>(TEntity entity) where TEntity : class;
    }
}
