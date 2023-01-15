﻿using Microsoft.EntityFrameworkCore;

namespace ParkplatzVerwaltungsTool.Models
{
    public class ParkingHouseContext : DbContext
    {
        public DbSet<ParkingHouse> ParkingHouses { get; set; }
        
        public string DbPath { get; }
        
        public ParkingHouseContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = "parkingHouseDb.db";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }

    //public class ParkingHouseLevelContext : DbContext
    //{
    //    public DbSet<ParkingHouse> ParkingHouses { get; set; }

    //    public string DbPath { get; }

    //    public ParkingHouseLevelContext()
    //    {
    //        var folder = Environment.SpecialFolder.LocalApplicationData;
    //        var path = Environment.GetFolderPath(folder);
    //        DbPath = "parkingHouseDb.db";
    //    }

    //    protected override void OnConfiguring(DbContextOptionsBuilder options)
    //        => options.UseSqlite($"Data Source={DbPath}");
    //}

    //public class ParkingPlaceContext : DbContext
    //{
    //    public DbSet<ParkingHouse> ParkingHouses { get; set; }

    //    public string DbPath { get; }

    //    public ParkingPlaceContext()
    //    {
    //        var folder = Environment.SpecialFolder.LocalApplicationData;
    //        var path = Environment.GetFolderPath(folder);
    //        DbPath = "parkingHouseDb.db";
    //    }

    //    protected override void OnConfiguring(DbContextOptionsBuilder options)
    //        => options.UseSqlite($"Data Source={DbPath}");
    //}
}