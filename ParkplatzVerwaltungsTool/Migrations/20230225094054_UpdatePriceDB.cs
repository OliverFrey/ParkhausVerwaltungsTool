using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkplatzVerwaltungsTool.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePriceDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParkingHouseLevels_ParkingHouses_ParkingHouseId",
                table: "ParkingHouseLevels");

            migrationBuilder.DropForeignKey(
                name: "FK_ParkingHouseViewModel_ParkingHouseLevels_ParkingHouseLevelsParkingHouseLevelId",
                table: "ParkingHouseViewModel");

            migrationBuilder.DropForeignKey(
                name: "FK_ParkingHouseViewModel_ParkingPlaces_ParkingPlacesParkingPlaceId",
                table: "ParkingHouseViewModel");

            migrationBuilder.DropForeignKey(
                name: "FK_ParkingPlaces_ParkingHouseLevels_ParkingHouseLevelId",
                table: "ParkingPlaces");

            migrationBuilder.DropIndex(
                name: "IX_ParkingHouseViewModel_ParkingHouseLevelsParkingHouseLevelId",
                table: "ParkingHouseViewModel");

            migrationBuilder.DropIndex(
                name: "IX_ParkingHouseViewModel_ParkingPlacesParkingPlaceId",
                table: "ParkingHouseViewModel");

            migrationBuilder.DropColumn(
                name: "ParkingHouseLevelsParkingHouseLevelId",
                table: "ParkingHouseViewModel");

            migrationBuilder.DropColumn(
                name: "ParkingPlacesParkingPlaceId",
                table: "ParkingHouseViewModel");

            migrationBuilder.AddColumn<int>(
                name: "ParkingHouseId",
                table: "Prices",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ParkingHouseLevelId",
                table: "ParkingPlaces",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ParkingHouseLevelName",
                table: "ParkingHouseLevels",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ParkingHouseId",
                table: "ParkingHouseLevels",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ParkingHouseLevels_ParkingHouses_ParkingHouseId",
                table: "ParkingHouseLevels",
                column: "ParkingHouseId",
                principalTable: "ParkingHouses",
                principalColumn: "ParkingHouseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ParkingPlaces_ParkingHouseLevels_ParkingHouseLevelId",
                table: "ParkingPlaces",
                column: "ParkingHouseLevelId",
                principalTable: "ParkingHouseLevels",
                principalColumn: "ParkingHouseLevelId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParkingHouseLevels_ParkingHouses_ParkingHouseId",
                table: "ParkingHouseLevels");

            migrationBuilder.DropForeignKey(
                name: "FK_ParkingPlaces_ParkingHouseLevels_ParkingHouseLevelId",
                table: "ParkingPlaces");

            migrationBuilder.DropColumn(
                name: "ParkingHouseId",
                table: "Prices");

            migrationBuilder.AlterColumn<int>(
                name: "ParkingHouseLevelId",
                table: "ParkingPlaces",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "ParkingHouseLevelsParkingHouseLevelId",
                table: "ParkingHouseViewModel",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ParkingPlacesParkingPlaceId",
                table: "ParkingHouseViewModel",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "ParkingHouseLevelName",
                table: "ParkingHouseLevels",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "ParkingHouseId",
                table: "ParkingHouseLevels",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.CreateIndex(
                name: "IX_ParkingHouseViewModel_ParkingHouseLevelsParkingHouseLevelId",
                table: "ParkingHouseViewModel",
                column: "ParkingHouseLevelsParkingHouseLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_ParkingHouseViewModel_ParkingPlacesParkingPlaceId",
                table: "ParkingHouseViewModel",
                column: "ParkingPlacesParkingPlaceId");

            migrationBuilder.AddForeignKey(
                name: "FK_ParkingHouseLevels_ParkingHouses_ParkingHouseId",
                table: "ParkingHouseLevels",
                column: "ParkingHouseId",
                principalTable: "ParkingHouses",
                principalColumn: "ParkingHouseId");

            migrationBuilder.AddForeignKey(
                name: "FK_ParkingHouseViewModel_ParkingHouseLevels_ParkingHouseLevelsParkingHouseLevelId",
                table: "ParkingHouseViewModel",
                column: "ParkingHouseLevelsParkingHouseLevelId",
                principalTable: "ParkingHouseLevels",
                principalColumn: "ParkingHouseLevelId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ParkingHouseViewModel_ParkingPlaces_ParkingPlacesParkingPlaceId",
                table: "ParkingHouseViewModel",
                column: "ParkingPlacesParkingPlaceId",
                principalTable: "ParkingPlaces",
                principalColumn: "ParkingPlaceId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ParkingPlaces_ParkingHouseLevels_ParkingHouseLevelId",
                table: "ParkingPlaces",
                column: "ParkingHouseLevelId",
                principalTable: "ParkingHouseLevels",
                principalColumn: "ParkingHouseLevelId");
        }
    }
}
