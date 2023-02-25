using Microsoft.EntityFrameworkCore;

namespace ParkplatzVerwaltungsTool.Models
{
    public class ParkingHouseSystemContext : DbContext
    {
        public DbSet<ParkingHouseViewModel> ParkingHouseViewModel { get; set; }
        public DbSet<ParkingHouse> ParkingHouses { get; set; }
        public DbSet<ParkingHouseLevel> ParkingHouseLevels { get; set; }
        //public DbSet<ParkingPlace> ParkingPlaces { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<PermamentUser> PermamentUsers { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        
        public string DbPath { get; }
        
        public ParkingHouseSystemContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = "parkingHouseDb.db";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }
}
