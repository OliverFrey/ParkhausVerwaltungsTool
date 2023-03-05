using System.ComponentModel.DataAnnotations;

namespace ParkplatzVerwaltungsTool.Models
{
    public class Price
    {
        [Key]
        public int PriceId { get; set; }
        public string PriceName { get; set; }
        public int ParkingHouseId { get; set; }
        public double PriceValue { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
    }

    public class Ticket
    {
        [Key]
        public int TicketId { get; set; }
        public DateTime EntryTime { get; set; }
        public DateTime ExitDate { get; set; }
        public double TotalCost { get; set; }
        public int ParkingHouseId { get; set; }
        public int ParkingPlaceId { get; set; }

        
    }
}
