using FluentAssertions;
using TravelAgency.DAL.Entities;
using TravelAgency.DAL.Repositories;
using TravelAgency.TestHelpers;

namespace TravelAgency.Repositories.Tests
{
    /// <summary>
    /// Тесты для <see cref="TicketWriteRepository"/>
    /// </summary>
    public class TicketWriteRepositoryTests : TravelAgencyContextInMemory
    {
        private readonly TicketWriteRepository ticketWriteRepository;

        /// <summary>
        /// инициализирует новый экземпляр <see cref="TicketWriteRepository"/>
        /// </summary>
        public TicketWriteRepositoryTests()
        {
            ticketWriteRepository = new TicketWriteRepository(Context);
        }

        /// <summary>
        /// CreateTicket должен cоздавать сущность
        /// </summary>
        [Fact]
        public void CreateTicketShouldCreate()
        {
            // Arrange
            var ticket = new Ticket()
            {
                Direction = "Тун-тун Сахур",
                AvailabilityWiFi = "No",
            };

            // Act
            ticketWriteRepository.Create(ticket);
            Context.SaveChanges();

            // Assert
            var result = Context.Tickets.FirstOrDefault(x => x.Direction == ticket.Direction);
            result.Should().NotBeNull();
        }

        /// <summary>
        /// UpdateTicket должен обновлять сущность
        /// </summary>
        [Fact]
        public void UpdateTicketShouldUpdate()
        {
            // Arrange
            var ticket = new Ticket()
            {
                Id = Guid.NewGuid(),
                Direction = "Тралалело Тралала",
            };
            Context.Add(ticket);
            Context.SaveChanges();
            Context.Entry(ticket).State = Microsoft.EntityFrameworkCore.EntityState.Detached;

            // Act
            var updatedTicket = new Ticket()
            {
                Id = ticket.Id,
                Direction = "Бомбардиро крокодило",
                DepartureDate = DateOnly.FromDateTime(DateTime.Now.AddDays(1)),
                NumberOfNights = 5,
                CostPerPerson = 100,
                PersonCount = 2,
                AvailabilityWiFi = "Yes",
                Surcharge = 2500,
                TotalCost = 3000,
            };
            ticketWriteRepository.Update(updatedTicket);
            Context.SaveChanges();

            // Assert
            var result = Context.Tickets.Find(ticket.Id);
            result.Direction.Should().BeEquivalentTo(updatedTicket.Direction);
            result.DepartureDate.Should().Be(updatedTicket.DepartureDate);
            result.NumberOfNights.Should().Be(updatedTicket.NumberOfNights);
            result.CostPerPerson.Should().Be(updatedTicket.CostPerPerson);
            result.PersonCount.Should().Be(updatedTicket.PersonCount);
            result.AvailabilityWiFi.Should().BeEquivalentTo(updatedTicket.AvailabilityWiFi);
            result.Surcharge.Should().Be(updatedTicket.Surcharge);
            result.TotalCost.Should().Be(updatedTicket.TotalCost);
        }

        /// <summary>
        /// DeleteTicket должен удалять сущность
        /// </summary>
        [Fact]
        public void DeleteTicketShouldDelete()
        {
            // Arrange
            var ticket = new Ticket()
            {
                Id = Guid.NewGuid(),
            };
            Context.Add(ticket);
            Context.SaveChanges();

            // Act
            ticketWriteRepository.Delete(ticket);
            Context.SaveChanges();

            // Assert
            var result = Context.Tickets.FirstOrDefault(x => x.Id == ticket.Id);
            result.Should().BeNull();
        }
    }
}
