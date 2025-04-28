using TravelAgency.DAL.Context.Contracts;
using Microsoft.EntityFrameworkCore;
using TravelAgency.DAL.Entities;
using TravelAgency.DAL.Repositories.Contracts;

namespace TravelAgency.DAL.Repositories
{
    /// <summary>
    /// Читает <see cref="Ticket"/> из репозитория
    /// </summary>
    public class TicketReadRepository : ITicketReadRepository
    {
        private readonly IDbReader _reader;

        /// <summary>
        /// Инициализирует новый экземпляр <see cref="TicketReadRepository"/>
        /// </summary>
        public TicketReadRepository(IDbReader reader)
        {
            _reader = reader;
        }

        /// <summary>
        /// Получение списка всех билетов
        /// </summary>
        public async Task<List<Ticket>> GetTicketsAsync()
            => await _reader.Read<Ticket>().ToListAsync();

        /// <summary>
        /// Получение билета по ID
        /// </summary>
        public async Task<Ticket?> GetTicketByIdAsync(Guid id)
            => await _reader.Read<Ticket>().FirstOrDefaultAsync(t => t.Id == id);
    }
}
