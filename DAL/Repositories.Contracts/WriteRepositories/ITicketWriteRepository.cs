using TravelAgency.DAL.Entities;

namespace TravelAgency.DAL.Repositories.Contracts
{
    /// <summary>
    /// Интерфейс репозитория для записи билета
    /// </summary>
    public interface ITicketWriteRepository
    {

        /// <summary>
        /// Добавление новой сущности
        /// </summary>
        void Create(Ticket entity);

        /// <summary>
        /// Удаление существующей сущности
        /// </summary>
        void Delete(Ticket entity);

        /// <summary>
        /// Редактироварие существующей сущности
        /// </summary>
        void Update(Ticket entity);
    }
}