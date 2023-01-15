using Microsoft.EntityFrameworkCore;

namespace ParkhausVerwaltungsTool.DataBaseModel
{
    public class User
    {
        public int UserId { get; set; }
        public string? UserType { get; set; }
    }

    public class PermamentUser
    {
        public int PermamentUserId { get; set; }
        public string? UserName { get; set; }
        public string? PlateNumber { get; set; }
        public DateTime? LastPayDate { get; set; }
        public int? ParkingPlaceId { get; set; }
        public string? EntryCode { get; set; }
    }
}
