using TravelAgency.DAL.Entities;

namespace TravelAgency.DAL.Repositories.Contracts
{
    public interface ITicketWriteRepository
    {
        void Create(Ticket entity);
        void Delete(Ticket entity);
        void Update(Ticket entity);
    }
}