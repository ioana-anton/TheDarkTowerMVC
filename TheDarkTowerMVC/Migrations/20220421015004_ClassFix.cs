using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheDarkTowerMVC.Migrations
{
    public partial class ClassFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CardDeckGameCard_GameCards_CardsId",
                table: "CardDeckGameCard");

            migrationBuilder.DropForeignKey(
                name: "FK_Inboxes_User_SenderId",
                table: "Inboxes");

            migrationBuilder.DropForeignKey(
                name: "FK_InboxRecipient_Inboxes_InboxId",
                table: "InboxRecipient");

            migrationBuilder.DropTable(
                name: "Friends");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Inboxes",
                table: "Inboxes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GameCards",
                table: "GameCards");

            migrationBuilder.RenameTable(
                name: "Inboxes",
                newName: "Inbox");

            migrationBuilder.RenameTable(
                name: "GameCards",
                newName: "GameCard");

            migrationBuilder.RenameIndex(
                name: "IX_Inboxes_SenderId",
                table: "Inbox",
                newName: "IX_Inbox_SenderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Inbox",
                table: "Inbox",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GameCard",
                table: "GameCard",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "FriendList",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FriendList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FriendList_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_FriendList_UserId",
                table: "FriendList",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CardDeckGameCard_GameCard_CardsId",
                table: "CardDeckGameCard",
                column: "CardsId",
                principalTable: "GameCard",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Inbox_User_SenderId",
                table: "Inbox",
                column: "SenderId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InboxRecipient_Inbox_InboxId",
                table: "InboxRecipient",
                column: "InboxId",
                principalTable: "Inbox",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CardDeckGameCard_GameCard_CardsId",
                table: "CardDeckGameCard");

            migrationBuilder.DropForeignKey(
                name: "FK_Inbox_User_SenderId",
                table: "Inbox");

            migrationBuilder.DropForeignKey(
                name: "FK_InboxRecipient_Inbox_InboxId",
                table: "InboxRecipient");

            migrationBuilder.DropTable(
                name: "FriendList");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Inbox",
                table: "Inbox");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GameCard",
                table: "GameCard");

            migrationBuilder.RenameTable(
                name: "Inbox",
                newName: "Inboxes");

            migrationBuilder.RenameTable(
                name: "GameCard",
                newName: "GameCards");

            migrationBuilder.RenameIndex(
                name: "IX_Inbox_SenderId",
                table: "Inboxes",
                newName: "IX_Inboxes_SenderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Inboxes",
                table: "Inboxes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GameCards",
                table: "GameCards",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Friends",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Friends", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Friends_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Friends_UserId",
                table: "Friends",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CardDeckGameCard_GameCards_CardsId",
                table: "CardDeckGameCard",
                column: "CardsId",
                principalTable: "GameCards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Inboxes_User_SenderId",
                table: "Inboxes",
                column: "SenderId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InboxRecipient_Inboxes_InboxId",
                table: "InboxRecipient",
                column: "InboxId",
                principalTable: "Inboxes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
