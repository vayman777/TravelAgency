namespace TravelAgency.DataAccess.Entities
{
    public class Ticket
    {
        public Guid Id { get; set; }
        public string Direction { get; set; }
        public DateOnly DepartureDate { get; set; }
        public int NumberOfNights { get; set; }
        public double CostPerPerson { get; set; }
        public int PersonCount { get; set; }
        public string AvailabilityWiFi  { get; set; }
        public double Surcharge { get; set; }
        public double TotalCost { get; set; }
    }
}
