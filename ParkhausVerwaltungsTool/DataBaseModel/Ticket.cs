namespace ParkhausVerwaltungsTool.DataBaseModel
{
    public class Ticket
    {
        public int TicketId { get; set; }
        public DateTime? EntryTime { get; set; }
        public DateTime? ExitTime { get; set; }
        public bool IsCompleted { get; set; }
    }

    public class Price
    {
        public int PriceId { get; set; }
        public string? PriceName { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int? Cost { get; set; }
    }
}
