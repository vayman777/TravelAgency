using Microsoft.EntityFrameworkCore;
using TravelAgency.Core.Models;

namespace TravelAgency.DataAccess.Repositories
{
    public class TicketRepository
    {
        private readonly TravelAgencyDbContext _context;

        public TicketRepository(TravelAgencyDbContext context) 
        {
            _context = context;
        }

        public async Task<List<TicketDto>> GetTickets()
        {
            var ticketEntities = await _context.Tickets.AsNoTracking().ToListAsync();

            var tickets = ticketEntities.Select(t => TicketDto.Create(t.Id, t.Direction, t.DepartureDate, t.NumberOfNights, t.CostPerPerson,
                t.PersonCount, t.AvailabilityWiFi, t.Surcharge, t.TotalCost).ticketDto).ToList();

            return tickets;
        }
    }
}
