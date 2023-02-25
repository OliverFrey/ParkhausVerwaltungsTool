using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkplatzVerwaltungsTool.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePermamentUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParkingPlaceNumber",
                table: "PermamentUsers",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParkingPlaceNumber",
                table: "PermamentUsers");
        }
    }
}
