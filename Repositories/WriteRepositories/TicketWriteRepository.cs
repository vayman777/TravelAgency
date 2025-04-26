using TravelAgency.DAL.Context.Contracts;
using TravelAgency.DAL.Entities;
using TravelAgency.DAL.Repositories.Contracts;

namespace TravelAgency.DAL.Repositories
{
    public class TicketWriteRepository : ITicketWriteRepository
    {
        private readonly IDbWriter _writer;

        public TicketWriteRepository(IDbWriter writer)
        {
            _writer = writer;
        }

        public void Create(Ticket entity)
            => _writer.Create(entity);

        public void Delete(Ticket entity)
            => _writer.Delete(entity);

        public void Update(Ticket entity)
            => _writer.Update(entity);
    }
}
