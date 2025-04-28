using FluentAssertions;
using TravelAgency.DAL.Entities;
using TravelAgency.DAL.Repositories;
using TravelAgency.TestHelpers;

namespace TravelAgency.Repositories.Tests
{
    /// <summary>
    /// ����� ��� <see cref="TicketReadRepository"/>
    /// </summary>
    public class TicketReadRepositoryTests : TravelAgencyContextInMemory
    {
        private readonly TicketReadRepository ticketReadRepository;

        /// <summary>
        /// �������������� ����� ��������� <see cref="TicketReadRepository"/>
        /// </summary>
        public TicketReadRepositoryTests() 
        {
            ticketReadRepository = new TicketReadRepository(Context);
        }

        /// <summary>
        /// GetTickets ������ ������� ��������
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
            var result = await ticketReadRepository.GetTicketsAsync();

            // Assert
            result.Should().NotBeNull();
            result.Select(x => x.Id).Should().BeEquivalentTo([ticket.Id]);
        }

        /// <summary>
        /// GetTickets ������ ������� ������ ��������
        /// </summary>
        [Fact]
        public async Task GetTicketsShouldReturnEmpty()
        {
            // Act
            var result = await ticketReadRepository.GetTicketsAsync();

            // Assert
            result.Should().BeEmpty();
        }

        /// <summary>
        /// GetTicketsById ������ ������� ��������
        /// </summary>
        [Fact]
        public async Task GetTicketsByIdShouldReturnValue()
        {
            // Arrange
            var ticket = new Ticket()
            {
                Id = Guid.NewGuid(),
            };
            Context.Add(ticket);
            await UnitOfWork.SaveChangesAsync();

            // Act
            var result = await ticketReadRepository.GetTicketByIdAsync(ticket.Id);

            // Assert
            result.Should().NotBeNull();
            result!.Id.Should().Be(ticket.Id);
        }

        /// <summary>
        /// GetTicketsById ������ ������� Null
        /// </summary>
        [Fact]
        public async Task GetTicketsByIdShouldReturnNull()
        {
            // Act
            var result = await ticketReadRepository.GetTicketByIdAsync(Guid.NewGuid());

            // Assert
            result.Should().BeNull();
        }
    }
}