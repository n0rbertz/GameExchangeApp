using Microsoft.EntityFrameworkCore.Migrations;

namespace GameExchangeApp.Data.Migrations
{
    public partial class LocationAddedToGamerModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Gamers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "Gamers");
        }
    }
}
