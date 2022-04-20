using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheDarkTowerMVC.Migrations
{
    public partial class GameCard : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDateTime",
                table: "CardDecks",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "byAdmin",
                table: "CardDecks",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "GameCards",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Power = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameCards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CardDeckGameCard",
                columns: table => new
                {
                    CardDeckId = table.Column<string>(type: "text", nullable: false),
                    CardsId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardDeckGameCard", x => new { x.CardDeckId, x.CardsId });
                    table.ForeignKey(
                        name: "FK_CardDeckGameCard_CardDecks_CardDeckId",
                        column: x => x.CardDeckId,
                        principalTable: "CardDecks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CardDeckGameCard_GameCards_CardsId",
                        column: x => x.CardsId,
                        principalTable: "GameCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CardDeckGameCard_CardsId",
                table: "CardDeckGameCard",
                column: "CardsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CardDeckGameCard");

            migrationBuilder.DropTable(
                name: "GameCards");

            migrationBuilder.DropColumn(
                name: "CreatedDateTime",
                table: "CardDecks");

            migrationBuilder.DropColumn(
                name: "byAdmin",
                table: "CardDecks");
        }
    }
}
