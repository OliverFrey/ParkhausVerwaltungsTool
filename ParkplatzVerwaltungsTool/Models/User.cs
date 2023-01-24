using System.ComponentModel.DataAnnotations;

namespace ParkplatzVerwaltungsTool.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public bool IsPermamentUser { get; set; }
    }

    public class PermamentUser
    {
        [Key]
        public int PermamentUserId { get; set; }
        public string PermamentUserName { get; set; }
        public string PlateNumber { get; set; }
        public ParkingPlace ParkingPlace { get; set; }
        public DateTime LastPayDate { get; set; }
    }
}
