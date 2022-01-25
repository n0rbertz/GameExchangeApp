using Microsoft.EntityFrameworkCore.Migrations;

namespace GameExchangeApp.Data.Migrations
{
    public partial class GameModelChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Games",
                newName: "Title");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Games",
                newName: "Name");
        }
    }
}
