using TravelAgency.DAL.Entities;

namespace TravelAgency.DAL.Repositories.Contracts
{
    /// <summary>
    /// Интерфейс для чтения <see cref="Ticket"/> из репозитория
    /// </summary>
    public interface ITicketReadRepository
    {
        /// <summary>
        /// Получение списка всех билетов
        /// </summary>
        Task<Ticket?> GetTicketByIdAsync(Guid id);

        /// <summary>
        /// Получение билета по ID
        /// </summary>
        Task<List<Ticket>> GetTicketsAsync();
    }
}