using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkplatzVerwaltungsTool.Migrations
{
    /// <inheritdoc />
    public partial class UpdateParkingHouse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Prices_ParkingHouseId",
                table: "Prices",
                column: "ParkingHouseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Prices_ParkingHouses_ParkingHouseId",
                table: "Prices",
                column: "ParkingHouseId",
                principalTable: "ParkingHouses",
                principalColumn: "ParkingHouseId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prices_ParkingHouses_ParkingHouseId",
                table: "Prices");

            migrationBuilder.DropIndex(
                name: "IX_Prices_ParkingHouseId",
                table: "Prices");
        }
    }
}
