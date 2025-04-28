using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using TravelAgency.DAL.Context;
using TravelAgency.DAL.Context.Contracts;

namespace TravelAgency.TestHelpers
{
    /// <summary>
    /// Контекст БД на оперативной памяти
    /// </summary>
    public class TravelAgencyContextInMemory
    {
        /// <summary>
        /// Контекст <see cref="TravelAgencyDbContext"/>
        /// </summary>
        protected TravelAgencyDbContext Context { get; }

        /// <inheritdoc cref="IUnitOfWork"/>
        protected IUnitOfWork UnitOfWork => Context;

        /// <summary>
        /// Инициализирует новый экземпляр <see cref="TravelAgencyContextInMemory"/>
        /// </summary>
        protected TravelAgencyContextInMemory()
        {
            var optionsBuilder = new DbContextOptionsBuilder<TravelAgencyDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .ConfigureWarnings(w => w.Ignore(InMemoryEventId.TransactionIgnoredWarning));
            Context = new TravelAgencyDbContext(optionsBuilder.Options);
        }
    }
}
