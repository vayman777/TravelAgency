namespace TravelAgency.Core.Contracts.Models
{
    /// <summary>
    /// DTO Модель билета
    /// </summary>
    public class TicketDto
    {
        /// <summary>
        /// ID
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Направление
        /// </summary>
        public string Direction { get; set; }

        /// <summary>
        /// Дата вылета
        /// </summary>
        public DateOnly DepartureDate { get; set; }

        /// <summary>
        /// Количество ночей
        /// </summary>
        public int NumberOfNights { get; set; }

        /// <summary>
        /// Стоимость за отдыхающего
        /// </summary>
        public double CostPerPerson { get; set; }

        /// <summary>
        /// Количество отдыхающих
        /// </summary>
        public int PersonCount { get; set; }

        /// <summary>
        /// Наличие Wi-Fi
        /// </summary>
        public string AvailabilityWiFi  { get; set; }

        /// <summary>
        /// Доплаты
        /// </summary>
        public double Surcharge { get; set; }

        /// <summary>
        /// Общая стоимость
        /// </summary>
        public double TotalCost { get; set; }
    }
}
