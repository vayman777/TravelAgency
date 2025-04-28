namespace TravelAgency.DAL.Context.Contracts
{ 
    /// <summary>
    /// Интерфейс для создания, удаления, редактирования данных с БД
    /// </summary>
    public interface IDbWriter
    {
        /// <summary>
        /// Добавление новой сущности
        /// </summary>
        void Create<TEntity>(TEntity entity) where TEntity : class;

        /// <summary>
        /// Удаление существующей сущности
        /// </summary>
        void Delete<TEntity>(TEntity entity) where TEntity : class;

        /// <summary>
        /// Редактироварие существующей сущности
        /// </summary>
        void Update<TEntity>(TEntity entity) where TEntity : class;
    }
}
