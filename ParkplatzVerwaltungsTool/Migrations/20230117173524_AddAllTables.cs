using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkplatzVerwaltungsTool.Migrations
{
    /// <inheritdoc />
    public partial class AddAllTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ParkingHouseLevels",
                columns: table => new
                {
                    ParkingHouseLevelId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ParkingHouseLevelName = table.Column<string>(type: "TEXT", nullable: true),
                    ParkingHouseId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkingHouseLevels", x => x.ParkingHouseLevelId);
                    table.ForeignKey(
                        name: "FK_ParkingHouseLevels_ParkingHouses_ParkingHouseId",
                        column: x => x.ParkingHouseId,
                        principalTable: "ParkingHouses",
                        principalColumn: "ParkingHouseId");
                });

            migrationBuilder.CreateTable(
                name: "Prices",
                columns: table => new
                {
                    PriceId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PriceName = table.Column<string>(type: "TEXT", nullable: false),
                    PriceValue = table.Column<int>(type: "INTEGER", nullable: false),
                    StartTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndTime = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prices", x => x.PriceId);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    TicketId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EntryTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ExitDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TotalCost = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.TicketId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IsPermamentUser = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "ParkingPlaces",
                columns: table => new
                {
                    ParkingPlaceId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ParkingPlaceNumber = table.Column<int>(type: "INTEGER", nullable: true),
                    ParkingHouseLevelId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkingPlaces", x => x.ParkingPlaceId);
                    table.ForeignKey(
                        name: "FK_ParkingPlaces_ParkingHouseLevels_ParkingHouseLevelId",
                        column: x => x.ParkingHouseLevelId,
                        principalTable: "ParkingHouseLevels",
                        principalColumn: "ParkingHouseLevelId");
                });

            migrationBuilder.CreateTable(
                name: "PermamentUsers",
                columns: table => new
                {
                    PermamentUserId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PermamentUserName = table.Column<string>(type: "TEXT", nullable: false),
                    PlateNumber = table.Column<string>(type: "TEXT", nullable: false),
                    ParkingPlaceId = table.Column<int>(type: "INTEGER", nullable: false),
                    LastPayDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermamentUsers", x => x.PermamentUserId);
                    table.ForeignKey(
                        name: "FK_PermamentUsers_ParkingPlaces_ParkingPlaceId",
                        column: x => x.ParkingPlaceId,
                        principalTable: "ParkingPlaces",
                        principalColumn: "ParkingPlaceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ParkingHouseLevels_ParkingHouseId",
                table: "ParkingHouseLevels",
                column: "ParkingHouseId");

            migrationBuilder.CreateIndex(
                name: "IX_ParkingPlaces_ParkingHouseLevelId",
                table: "ParkingPlaces",
                column: "ParkingHouseLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_PermamentUsers_ParkingPlaceId",
                table: "PermamentUsers",
                column: "ParkingPlaceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PermamentUsers");

            migrationBuilder.DropTable(
                name: "Prices");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "ParkingPlaces");

            migrationBuilder.DropTable(
                name: "ParkingHouseLevels");
        }
    }
}
