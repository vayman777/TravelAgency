using TravelAgency.DAL.Context.Contracts;
using Microsoft.EntityFrameworkCore;
using TravelAgency.DAL.Entities;
using TravelAgency.DAL.Repositories.Contracts;

namespace TravelAgency.DAL.Repositories
{
    public class TicketReadRepository : ITicketReadRepository
    {
        private readonly IDbReader _reader;

        public TicketReadRepository(IDbReader reader)
        {
            _reader = reader;
        }

        public async Task<List<Ticket>> GetTicketsAsync()
            => await _reader.Read<Ticket>().ToListAsync();

        public async Task<Ticket?> GetTicketByIdAsync(Guid id)
            => await _reader.Read<Ticket>().FirstOrDefaultAsync(t => t.Id == id);
    }
}
