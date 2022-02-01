using Microsoft.EntityFrameworkCore.Migrations;

namespace GameExchangeApp.Data.Migrations
{
    public partial class GamerModelInversePropertyAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameGamer_Gamers_GamersId",
                table: "GameGamer");

            migrationBuilder.DropForeignKey(
                name: "FK_GameGamer_Games_GamesId",
                table: "GameGamer");

            migrationBuilder.RenameColumn(
                name: "GamesId",
                table: "GameGamer",
                newName: "GamesDemandedId");

            migrationBuilder.RenameColumn(
                name: "GamersId",
                table: "GameGamer",
                newName: "DemandedById");

            migrationBuilder.RenameIndex(
                name: "IX_GameGamer_GamesId",
                table: "GameGamer",
                newName: "IX_GameGamer_GamesDemandedId");

            migrationBuilder.CreateTable(
                name: "GameGamer1",
                columns: table => new
                {
                    GamesOwnedId = table.Column<int>(type: "int", nullable: false),
                    OwnedById = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameGamer1", x => new { x.GamesOwnedId, x.OwnedById });
                    table.ForeignKey(
                        name: "FK_GameGamer1_Gamers_OwnedById",
                        column: x => x.OwnedById,
                        principalTable: "Gamers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameGamer1_Games_GamesOwnedId",
                        column: x => x.GamesOwnedId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameGamer1_OwnedById",
                table: "GameGamer1",
                column: "OwnedById");

            migrationBuilder.AddForeignKey(
                name: "FK_GameGamer_Gamers_DemandedById",
                table: "GameGamer",
                column: "DemandedById",
                principalTable: "Gamers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GameGamer_Games_GamesDemandedId",
                table: "GameGamer",
                column: "GamesDemandedId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameGamer_Gamers_DemandedById",
                table: "GameGamer");

            migrationBuilder.DropForeignKey(
                name: "FK_GameGamer_Games_GamesDemandedId",
                table: "GameGamer");

            migrationBuilder.DropTable(
                name: "GameGamer1");

            migrationBuilder.RenameColumn(
                name: "GamesDemandedId",
                table: "GameGamer",
                newName: "GamesId");

            migrationBuilder.RenameColumn(
                name: "DemandedById",
                table: "GameGamer",
                newName: "GamersId");

            migrationBuilder.RenameIndex(
                name: "IX_GameGamer_GamesDemandedId",
                table: "GameGamer",
                newName: "IX_GameGamer_GamesId");

            migrationBuilder.AddForeignKey(
                name: "FK_GameGamer_Gamers_GamersId",
                table: "GameGamer",
                column: "GamersId",
                principalTable: "Gamers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GameGamer_Games_GamesId",
                table: "GameGamer",
                column: "GamesId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
