using TravelAgency.Core.Contracts.Models;

namespace TravelAgency.Core.Services
{
    /// <summary>
    /// Интерфейс сервиса по работе с билетами
    /// </summary>
    public interface ITicketService
    {
        /// <summary>
        /// Создание билета
        /// </summary>
        Task CreateAsync(TicketDto entity);

        /// <summary>
        /// Удаление билета по ID
        /// </summary>
        Task DeleteAsync(Guid? id);

        /// <summary>
        /// Получение билета по ID
        /// </summary>
        Task<TicketDto?> GetTicketByIdAsync(Guid? id);

        /// <summary>
        /// Получение списка всех билетов
        /// </summary>
        Task<List<TicketDto>> GetTicketsAsync();

        /// <summary>
        /// Редактирование билета
        /// </summary>
        Task UpdateAsync(TicketDto entity);
    }
}