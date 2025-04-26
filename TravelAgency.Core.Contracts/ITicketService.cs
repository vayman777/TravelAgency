using TravelAgency.Core.Contracts.Models;

namespace TravelAgency.Core.Services
{
    public interface ITicketService
    {
        Task CreateAsync(TicketDto entity);
        Task DeleteAsync(Guid? id);
        Task<TicketDto?> GetTicketByIdAsync(Guid? id);
        Task<List<TicketDto>> GetTicketsAsync();
        Task UpdateAsync(TicketDto entity);
    }
}