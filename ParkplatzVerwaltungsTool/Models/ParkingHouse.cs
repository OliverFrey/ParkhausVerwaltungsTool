using Microsoft.CodeAnalysis.Elfie.Model.Tree;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ParkplatzVerwaltungsTool.Models
{
    [Keyless]
    public class ParkingHouseViewModel
    {
        public ParkingHouse ParkingHouses { get; set; }
        public List<ParkingHouseLevel> ParkingHouseLevels { get; set; }
        //public List<ParkingPlace> ParkingPlaces { get; set; }
    }

    public class ParkingHouse
    {
        [Key]
        public int ParkingHouseId { get; set; }
        public string ParkingHouseName { get; set; }
        public List<ParkingHouseLevel> ParkingHouseLevels { get; set; }
        public List<Price> Prices { get; set; }

        public ParkingHouse()
        {
            ParkingHouseLevels = new List<ParkingHouseLevel>();
            Prices = new List<Price>();
        }
    }

    public class ParkingHouseLevel
    {
        [Key]
        public int ParkingHouseLevelId { get; set; }
        public int ParkingHouseId { get; set; }
        public string ParkingHouseLevelName { get; set; }
        public List<ParkingPlace> ParkingPlaces { get; set; }

        //public ParkingHouseLevel()
        //{
        //    ParkingPlaces = new List<ParkingPlace>();
        //}
    }

    public class ParkingPlace
    {
        [Key]
        public int ParkingPlaceId { get; set; }
        public int ParkingHouseLevelId { get; set; }
        public int? ParkingPlaceNumber { get; set; }
    }
}
