using TravelAgency.DAL.Context.Contracts;
using TravelAgency.DAL.Repositories.Contracts;
using TravelAgency.Core.Contracts.Models;
using TravelAgency.DAL.Entities;

namespace TravelAgency.Core.Services
{
    /// <summary>
    /// Сервис по работе с билетами
    /// </summary>
    public class TicketService : ITicketService
    {
        private readonly ITicketReadRepository ticketReadRepository;
        private readonly ITicketWriteRepository ticketWriteRepository;
        private readonly IUnitOfWork unitOfWork;

        /// <summary>
        /// Конструктор <see cref="TicketService"/>
        /// </summary>
        public TicketService(ITicketReadRepository ticketReadRepository,
            ITicketWriteRepository ticketWriteRepository,
            IUnitOfWork unitOfWork)
        {
            this.ticketReadRepository = ticketReadRepository;
            this.ticketWriteRepository = ticketWriteRepository;
            this.unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Получение билета по ID
        /// </summary>
        public async Task<TicketDto?> GetTicketByIdAsync(Guid? id)
        {
            if (id == null)
            {
                throw new NullReferenceException("Ticket not found");
            }
            var ticket = await ticketReadRepository.GetTicketByIdAsync(id.Value);
            if (ticket == null)
            {
                throw new NullReferenceException("Ticket not found");
            }
            var ticketDto = new TicketDto()
            {
                Id = ticket.Id,
                Direction = ticket.Direction,
                DepartureDate = ticket.DepartureDate,
                NumberOfNights = ticket.NumberOfNights,
                CostPerPerson = ticket.CostPerPerson,
                PersonCount = ticket.PersonCount,
                AvailabilityWiFi = ticket.AvailabilityWiFi,
                Surcharge = ticket.Surcharge,
                TotalCost = ticket.TotalCost
            };
            return ticketDto;
        }

        /// <summary>
        /// Получение списка всех билетов
        /// </summary>
        public async Task<List<TicketDto>> GetTicketsAsync()
        {
            var tickets = await ticketReadRepository.GetTicketsAsync();
            return tickets.Select(t => new TicketDto()
            {
                Id = t.Id,
                Direction = t.Direction,
                DepartureDate = t.DepartureDate,
                NumberOfNights = t.NumberOfNights,
                CostPerPerson = t.CostPerPerson,
                PersonCount = t.PersonCount,
                AvailabilityWiFi = t.AvailabilityWiFi,
                Surcharge = t.Surcharge,
                TotalCost = t.TotalCost
            }).ToList();
        }

        /// <summary>
        /// Создание билета
        /// </summary>
        public async Task CreateAsync(TicketDto entity)
        {
            entity.TotalCost = (entity.CostPerPerson * entity.PersonCount) + entity.Surcharge;
            var ticket = new Ticket()
            {
                Id = Guid.NewGuid(),
                Direction = entity.Direction,
                DepartureDate = entity.DepartureDate,
                NumberOfNights = entity.NumberOfNights,
                CostPerPerson = entity.CostPerPerson,
                PersonCount = entity.PersonCount,
                AvailabilityWiFi = entity.AvailabilityWiFi,
                Surcharge = entity.Surcharge,
                TotalCost = entity.TotalCost
            };
            ticketWriteRepository.Create(ticket);
            await unitOfWork.SaveChangesAsync();
        }

        /// <summary>
        /// Удаление билета по ID
        /// </summary>
        public async Task DeleteAsync(Guid? id)
        {
            if (id.HasValue)
            {
                var ticket = await ticketReadRepository.GetTicketByIdAsync(id.Value);
                if (ticket != null)
                {
                    ticketWriteRepository.Delete(ticket);
                    await unitOfWork.SaveChangesAsync();
                }
                else
                {
                    throw new NullReferenceException("Ticket not found");
                }
            }
            else
            {
                throw new NullReferenceException("ID is null");
            }
        }

        /// <summary>
        /// Редактирование билета
        /// </summary>
        public async Task UpdateAsync(TicketDto entity)
        {
            entity.TotalCost = (entity.CostPerPerson * entity.PersonCount) + entity.Surcharge;
            var ticket = new Ticket()
            {
                Id = entity.Id,
                Direction = entity.Direction,
                DepartureDate = entity.DepartureDate,
                NumberOfNights = entity.NumberOfNights,
                CostPerPerson = entity.CostPerPerson,
                PersonCount = entity.PersonCount,
                AvailabilityWiFi = entity.AvailabilityWiFi,
                Surcharge = entity.Surcharge,
                TotalCost = entity.TotalCost
            };
            ticketWriteRepository.Update(ticket);
            await unitOfWork.SaveChangesAsync();
        }


    }
}
