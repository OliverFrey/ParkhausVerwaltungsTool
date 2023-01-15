using System.ComponentModel.DataAnnotations;

namespace ParkplatzVerwaltungsTool.Models
{
    public class ParkingHouse
    {
        [Key]
        public int ParkingHouseId { get; set; }
        public string? ParkingHouseName { get; set; }
        //public ICollection<ParkingHouseLevel>? ParkingHouseLevels { get; set; }
    }

    //public class ParkingHouseLevel
    //{
    //    [Key]
    //    public int ParkingHouseLevelId { get; set; }
    //    public string? ParkingHouseLevelName { get; set; }
    //    public ICollection<ParkingPlace>? ParkingPlaces { get; set; }
    //}

    //public class ParkingPlace
    //{
    //    [Key]
    //    public int ParkingPlaceId { get; set; }
    //    public int? ParkingPlaceNumber { get; set; }
    //}
}
