using Microsoft.EntityFrameworkCore.Migrations;

namespace GameExchangeApp.Data.Migrations
{
    public partial class ImageAddedToGameModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameGamer");

            migrationBuilder.DropTable(
                name: "GameGamer1");

            migrationBuilder.DropTable(
                name: "Gamers");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Games",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ApplicationUserGame",
                columns: table => new
                {
                    DemandedById = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GamesDemandedId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserGame", x => new { x.DemandedById, x.GamesDemandedId });
                    table.ForeignKey(
                        name: "FK_ApplicationUserGame_AspNetUsers_DemandedById",
                        column: x => x.DemandedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationUserGame_Games_GamesDemandedId",
                        column: x => x.GamesDemandedId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationUserGame1",
                columns: table => new
                {
                    GamesOwnedId = table.Column<int>(type: "int", nullable: false),
                    OwnedById = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserGame1", x => new { x.GamesOwnedId, x.OwnedById });
                    table.ForeignKey(
                        name: "FK_ApplicationUserGame1_AspNetUsers_OwnedById",
                        column: x => x.OwnedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationUserGame1_Games_GamesOwnedId",
                        column: x => x.GamesOwnedId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserGame_GamesDemandedId",
                table: "ApplicationUserGame",
                column: "GamesDemandedId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserGame1_OwnedById",
                table: "ApplicationUserGame1",
                column: "OwnedById");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationUserGame");

            migrationBuilder.DropTable(
                name: "ApplicationUserGame1");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "Gamers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gamers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GameGamer",
                columns: table => new
                {
                    DemandedById = table.Column<int>(type: "int", nullable: false),
                    GamesDemandedId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameGamer", x => new { x.DemandedById, x.GamesDemandedId });
                    table.ForeignKey(
                        name: "FK_GameGamer_Gamers_DemandedById",
                        column: x => x.DemandedById,
                        principalTable: "Gamers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameGamer_Games_GamesDemandedId",
                        column: x => x.GamesDemandedId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "IX_GameGamer_GamesDemandedId",
                table: "GameGamer",
                column: "GamesDemandedId");

            migrationBuilder.CreateIndex(
                name: "IX_GameGamer1_OwnedById",
                table: "GameGamer1",
                column: "OwnedById");
        }
    }
}
