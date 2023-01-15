﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ParkplatzVerwaltungsTool.Models;

#nullable disable

namespace ParkplatzVerwaltungsTool.Migrations
{
    [DbContext(typeof(ParkingHouseContext))]
    [Migration("20230115111913_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.2");

            modelBuilder.Entity("ParkplatzVerwaltungsTool.Models.ParkingHouse", b =>
                {
                    b.Property<int>("ParkingHouseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ParkingHouseName")
                        .HasColumnType("TEXT");

                    b.HasKey("ParkingHouseId");

                    b.ToTable("ParkingHouses");
                });
#pragma warning restore 612, 618
        }
    }
}
