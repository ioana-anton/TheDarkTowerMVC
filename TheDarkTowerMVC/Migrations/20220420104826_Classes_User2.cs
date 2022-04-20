using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheDarkTowerMVC.Migrations
{
    public partial class Classes_User2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CardDeck_User_UserId",
                table: "CardDeck");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CardDeck",
                table: "CardDeck");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "User");

            migrationBuilder.RenameTable(
                name: "CardDeck",
                newName: "CardDecks");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "User",
                newName: "Username");

            migrationBuilder.RenameIndex(
                name: "IX_CardDeck_UserId",
                table: "CardDecks",
                newName: "IX_CardDecks_UserId");

            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "User",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CardDecks",
                table: "CardDecks",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CardDecks_User_UserId",
                table: "CardDecks",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CardDecks_User_UserId",
                table: "CardDecks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CardDecks",
                table: "CardDecks");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "User");

            migrationBuilder.RenameTable(
                name: "CardDecks",
                newName: "CardDeck");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "User",
                newName: "Name");

            migrationBuilder.RenameIndex(
                name: "IX_CardDecks_UserId",
                table: "CardDeck",
                newName: "IX_CardDeck_UserId");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "User",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CardDeck",
                table: "CardDeck",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CardDeck_User_UserId",
                table: "CardDeck",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
