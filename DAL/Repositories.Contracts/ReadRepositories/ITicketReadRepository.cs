using TravelAgency.DAL.Entities;

namespace TravelAgency.DAL.Repositories.Contracts
{
    public interface ITicketReadRepository
    {
        Task<Ticket?> GetTicketByIdAsync(Guid id);
        Task<List<Ticket>> GetTicketsAsync();
    }
}