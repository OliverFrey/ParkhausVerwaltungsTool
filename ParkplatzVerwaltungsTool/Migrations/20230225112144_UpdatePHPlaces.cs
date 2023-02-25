using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkplatzVerwaltungsTool.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePHPlaces : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PermamentUsers_ParkingPlaces_ParkingPlaceId",
                table: "PermamentUsers");

            migrationBuilder.DropTable(
                name: "ParkingPlaces");

            migrationBuilder.DropIndex(
                name: "IX_PermamentUsers_ParkingPlaceId",
                table: "PermamentUsers");

            migrationBuilder.DropColumn(
                name: "ParkingPlaceId",
                table: "PermamentUsers");

            migrationBuilder.AddColumn<int>(
                name: "ParkingPlaces",
                table: "ParkingHouseLevels",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParkingPlaces",
                table: "ParkingHouseLevels");

            migrationBuilder.AddColumn<int>(
                name: "ParkingPlaceId",
                table: "PermamentUsers",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ParkingPlaces",
                columns: table => new
                {
                    ParkingPlaceId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ParkingHouseLevelId = table.Column<int>(type: "INTEGER", nullable: false),
                    ParkingPlaceNumber = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkingPlaces", x => x.ParkingPlaceId);
                    table.ForeignKey(
                        name: "FK_ParkingPlaces_ParkingHouseLevels_ParkingHouseLevelId",
                        column: x => x.ParkingHouseLevelId,
                        principalTable: "ParkingHouseLevels",
                        principalColumn: "ParkingHouseLevelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PermamentUsers_ParkingPlaceId",
                table: "PermamentUsers",
                column: "ParkingPlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_ParkingPlaces_ParkingHouseLevelId",
                table: "ParkingPlaces",
                column: "ParkingHouseLevelId");

            migrationBuilder.AddForeignKey(
                name: "FK_PermamentUsers_ParkingPlaces_ParkingPlaceId",
                table: "PermamentUsers",
                column: "ParkingPlaceId",
                principalTable: "ParkingPlaces",
                principalColumn: "ParkingPlaceId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
