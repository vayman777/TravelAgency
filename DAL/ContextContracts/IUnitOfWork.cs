namespace TravelAgency.DAL.Context.Contracts
{
    /// <summary>
    /// Паттерн проектирования UnitOfWork
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// Асинхронное сохранение изменений
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
