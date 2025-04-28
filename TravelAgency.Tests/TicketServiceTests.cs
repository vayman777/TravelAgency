using FluentAssertions;
using TravelAgency.Core.Contracts.Models;
using TravelAgency.Core.Services;
using TravelAgency.DAL.Entities;
using TravelAgency.DAL.Repositories;
using TravelAgency.TestHelpers;

namespace TravelAgency.Services.Tests
{
    /// <summary>
    /// Тесты для <see cref="TicketService"/>
    /// </summary>
    public class TicketServiceTests : TravelAgencyContextInMemory
    {
        private ITicketService ticketService;

        /// <summary>
        /// инициализирует новый экземпляр <see cref="TicketServiceTests"/>
        /// </summary>
        public TicketServiceTests()
        {
            var writeRepository = new TicketWriteRepository(Context);
            var readRepository = new TicketReadRepository(Context);
            ticketService = new TicketService(readRepository, writeRepository, Context);
        }

        /// <summary>
        /// GetTicketById должен вернуть значение
        /// </summary>
        [Fact]
        public async Task GetTicketByIdShouldReturnValue()
        {
            // Arrange
            var ticket = new Ticket()
            {
                Id = Guid.NewGuid(),
            };
            Context.Add(ticket);
            await UnitOfWork.SaveChangesAsync();

            // Act
            var result = await ticketService.GetTicketByIdAsync(ticket.Id);

            // Assert
            result.Should().NotBeNull();
            result!.Id.Should().Be(ticket.Id);
        }

        /// <summary>
        /// GetTicketById должен бросить исключение. Не найден билет по ID
        /// </summary>
        [Fact]
        public async Task GetTicketByIdShouldThrowExceptionNotFound()
        {
            // Act
            var act = () => ticketService.GetTicketByIdAsync(Guid.NewGuid());

            // Assert
            await act.Should().ThrowAsync<NullReferenceException>();
        }

        /// <summary>
        /// GetTicketById должен бросить исключение
        /// </summary>
        [Fact]
        public async Task GetTicketByIdShouldThrowException()
        {
            // Act
            var act = () => ticketService.GetTicketByIdAsync(null);

            // Assert
            await act.Should().ThrowAsync<NullReferenceException>();
        }

        /// <summary>
        /// GetTickets должен вернуть значение
        /// </summary>
        [Fact]
        public async Task GetTicketsShouldReturnValue()
        {
            // Arrange
            var ticket = new Ticket()
            {
                Id = Guid.NewGuid(),
            };
            Context.Add(ticket);
            await UnitOfWork.SaveChangesAsync();

            // Act
            var result = await ticketService.GetTicketsAsync();

            // Assert
            result.Should().NotBeNull();
            result.Select(x => x.Id).Should().BeEquivalentTo([ticket.Id]);
        }

        /// <summary>
        /// GetTickets должен вернуть пустое значение
        /// </summary>
        [Fact]
        public async Task GetTicketsShouldReturnEmpty()
        {
            // Act
            var result = await ticketService.GetTicketsAsync();

            // Assert
            result.Should().BeEmpty();
        }

        /// <summary>
        /// UpdateTickets должен обновлять сущность
        /// </summary>
        [Fact]
        public async Task UpdateTicketsShouldUpdate()
        {
            // Arrange
            var ticket = new Ticket()
            {
                Id = Guid.NewGuid(),
            };
            Context.Add(ticket);
            await UnitOfWork.SaveChangesAsync();
            Context.Entry(ticket).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
            var ticketDto = new TicketDto()
            {
                Id = ticket.Id,
                Direction = "Бомбардино Крокодило",
                DepartureDate = DateOnly.FromDateTime(DateTime.Now.AddDays(1)),
                NumberOfNights = 5,
                CostPerPerson = 100,
                PersonCount = 2,
                AvailabilityWiFi = "Yes",
                Surcharge = 2500,
                TotalCost = 3000,
            };

            // Act
            await ticketService.UpdateAsync(ticketDto);

            // Assert
            var result = Context.Tickets.Find(ticket.Id);
            result.Direction.Should().BeEquivalentTo(ticketDto.Direction);
            result.DepartureDate.Should().Be(ticketDto.DepartureDate);
            result.NumberOfNights.Should().Be(ticketDto.NumberOfNights);
            result.CostPerPerson.Should().Be(ticketDto.CostPerPerson);
            result.PersonCount.Should().Be(ticketDto.PersonCount);
            result.AvailabilityWiFi.Should().BeEquivalentTo(ticketDto.AvailabilityWiFi);
            result.Surcharge.Should().Be(ticketDto.Surcharge);
            result.TotalCost.Should().Be(ticketDto.TotalCost);
        }

        /// <summary>
        /// CreateTicket должен cоздавать сущность
        /// </summary>
        [Fact]
        public async Task CreateTicketShouldCreate()
        {
            // Arrange
            var ticketDto = new TicketDto()
            {
                Direction = "Тун-тун Сахур",
                AvailabilityWiFi = "No",
            };

            // Act
            await ticketService.CreateAsync(ticketDto);

            // Assert
            var result = Context.Tickets.FirstOrDefault(x => x.Direction == ticketDto.Direction);
            result.Should().NotBeNull();
        }

        /// <summary>
        /// DeleteTicket должен удалять сущность
        /// </summary>
        [Fact]
        public async Task DeleteTicketShouldDelete()
        {
            // Arrange
            var ticket = new Ticket()
            {
                Id = Guid.NewGuid(),
            };
            Context.Add(ticket);
            await UnitOfWork.SaveChangesAsync();
            Context.Entry(ticket).State = Microsoft.EntityFrameworkCore.EntityState.Detached;

            // Act
            await ticketService.DeleteAsync(ticket.Id);

            // Assert
            var result = Context.Tickets.FirstOrDefault(x => x.Id == ticket.Id);
            result.Should().BeNull();
        }

        /// <summary>
        /// DeleteTicket должен бросить исключение. Не найден билет по ID
        /// </summary>
        [Fact]
        public async Task DeleteTicketShouldThrowExceptionNotFound()
        {
            // Act
            var act = () => ticketService.DeleteAsync(Guid.NewGuid());

            // Assert
            await act.Should().ThrowAsync<NullReferenceException>();
        }

        /// <summary>
        /// DeleteTicket должен бросить исключение
        /// </summary>
        [Fact]
        public async Task DeleteTicketShouldThrowException()
        {
            // Act
            var act = () => ticketService.DeleteAsync(null);

            // Assert
            await act.Should().ThrowAsync<NullReferenceException>();
        }
    }
}