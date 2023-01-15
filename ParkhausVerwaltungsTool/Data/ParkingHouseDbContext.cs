using Microsoft.EntityFrameworkCore;

namespace ParkhausVerwaltungsTool.Data
{
    public class ParkingHouseDbContext : DbContext
    {
        public ParkingHouseDbContext (DbContextOptions<ParkingHouseDbContext> options) : base(options)
        {

        }

        public DbSet<ParkhausVerwaltungsTool.DataBaseModel.ParkingHouse> ParkingHouse => Set<ParkhausVerwaltungsTool.DataBaseModel.ParkingHouse>();
    }
}
