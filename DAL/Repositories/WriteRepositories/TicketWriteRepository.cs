using TravelAgency.DAL.Context.Contracts;
using TravelAgency.DAL.Entities;
using TravelAgency.DAL.Repositories.Contracts;

namespace TravelAgency.DAL.Repositories
{
    /// <summary>
    /// Репозиторий для записи билета
    /// </summary>
    public class TicketWriteRepository : ITicketWriteRepository
    {
        private readonly IDbWriter _writer;

        /// <summary>
        /// Инициализирует новый экземпляр <see cref="TicketWriteRepository"/>
        /// </summary>
        public TicketWriteRepository(IDbWriter writer)
        {
            _writer = writer;
        }

        /// <summary>
        /// Добавление новой сущности
        /// </summary>
        public void Create(Ticket entity)
            => _writer.Create(entity);

        /// <summary>
        /// Удаление существующей сущности
        /// </summary>
        public void Delete(Ticket entity)
            => _writer.Delete(entity);

        /// <summary>
        /// Редактироварие существующей сущности
        /// </summary>
        public void Update(Ticket entity)
            => _writer.Update(entity);
    }
}
