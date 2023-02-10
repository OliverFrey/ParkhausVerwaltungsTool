using Microsoft.CodeAnalysis.Elfie.Model.Tree;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ParkplatzVerwaltungsTool.Models
{
    [Keyless]
    public class ParkingHouseViewModel
    {
        public ParkingHouse ParkingHouses { get; set; }
        public ParkingHouseLevel ParkingHouseLevels { get; set; }
        public ParkingPlace ParkingPlaces { get; set; }
    }

    public class ParkingHouse
    {
        [Key]
        public int ParkingHouseId { get; set; }
        public string ParkingHouseName { get; set; }
        public ICollection<ParkingHouseLevel> ParkingHouseLevels { get; set; }

        public ParkingHouse()
        {
            ParkingHouseLevels = new List<ParkingHouseLevel>();
        }
    }

    public class ParkingHouseLevel
    {
        [Key]
        public int ParkingHouseLevelId { get; set; }
        public int ParkingHouseId { get; set; }
        public string ParkingHouseLevelName { get; set; }
        public ICollection<ParkingPlace> ParkingPlaces { get; set; }

        public ParkingHouseLevel()
        {
            ParkingPlaces = new List<ParkingPlace>();
        }

        public static async Task<List<ParkingHouseLevel>> GetParkingHouseLevelsByParkingHouseId (int parkingHouseId)
        {
            var temp = new List<ParkingHouseLevel>();
            return temp;
        }
    }

    public class ParkingPlace
    {
        [Key]
        public int ParkingPlaceId { get; set; }
        public int ParkingHouseLevelId { get; set; }
        public int? ParkingPlaceNumber { get; set; }
    }
}
