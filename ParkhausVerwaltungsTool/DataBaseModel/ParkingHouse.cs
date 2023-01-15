namespace ParkhausVerwaltungsTool.DataBaseModel
{
    public class ParkingHouse
    {
        public int ParkingHouseId { get; set; }
        public string? ParkingHouseName { get; set; }
        public ICollection<ParkingEtage>? Etages { get; set; }
        public ICollection<Price>? PriceList { get; set; }
    }

    public class ParkingEtage
    {
        public int ParkingEtageId { get; set; }
        public string? ParkingEtageName { get; set; }
        public ICollection<ParkingPlace>? Places { get; set; }
    }

    public class ParkingPlace
    {
        public int ParkingPlaceId { get; set; }
        public int? ParkingPlaceName { get; set; }
    }
}
