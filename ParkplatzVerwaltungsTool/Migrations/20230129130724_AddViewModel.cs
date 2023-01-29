using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkplatzVerwaltungsTool.Migrations
{
    /// <inheritdoc />
    public partial class AddViewModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ParkingHouseViewModel",
                columns: table => new
                {
                    ParkingHousesParkingHouseId = table.Column<int>(type: "INTEGER", nullable: false),
                    ParkingHouseLevelsParkingHouseLevelId = table.Column<int>(type: "INTEGER", nullable: false),
                    ParkingPlacesParkingPlaceId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_ParkingHouseViewModel_ParkingHouseLevels_ParkingHouseLevelsParkingHouseLevelId",
                        column: x => x.ParkingHouseLevelsParkingHouseLevelId,
                        principalTable: "ParkingHouseLevels",
                        principalColumn: "ParkingHouseLevelId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParkingHouseViewModel_ParkingHouses_ParkingHousesParkingHouseId",
                        column: x => x.ParkingHousesParkingHouseId,
                        principalTable: "ParkingHouses",
                        principalColumn: "ParkingHouseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParkingHouseViewModel_ParkingPlaces_ParkingPlacesParkingPlaceId",
                        column: x => x.ParkingPlacesParkingPlaceId,
                        principalTable: "ParkingPlaces",
                        principalColumn: "ParkingPlaceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ParkingHouseViewModel_ParkingHouseLevelsParkingHouseLevelId",
                table: "ParkingHouseViewModel",
                column: "ParkingHouseLevelsParkingHouseLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_ParkingHouseViewModel_ParkingHousesParkingHouseId",
                table: "ParkingHouseViewModel",
                column: "ParkingHousesParkingHouseId");

            migrationBuilder.CreateIndex(
                name: "IX_ParkingHouseViewModel_ParkingPlacesParkingPlaceId",
                table: "ParkingHouseViewModel",
                column: "ParkingPlacesParkingPlaceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ParkingHouseViewModel");
        }
    }
}
