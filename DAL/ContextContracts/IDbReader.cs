namespace TravelAgency.DAL.Context.Contracts
{
    /// <summary>
    /// Интерфейс для получения данных с контекста БД
    /// </summary>
    public interface IDbReader
    {
        /// <summary>
        /// Запрос на чтение 
        /// </summary>
        IQueryable<TEntity> Read<TEntity>() where TEntity : class;
    }
}
