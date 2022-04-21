using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheDarkTowerMVC.Migrations
{
    public partial class FriendList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InboxRecipient_Recipient_RecipientsId",
                table: "InboxRecipient");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipient_User_ReceiverId",
                table: "Recipient");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Recipient",
                table: "Recipient");

            migrationBuilder.RenameTable(
                name: "Recipient",
                newName: "Recipients");

            migrationBuilder.RenameIndex(
                name: "IX_Recipient_ReceiverId",
                table: "Recipients",
                newName: "IX_Recipients_ReceiverId");

            migrationBuilder.AlterColumn<string>(
                name: "ReceiverId",
                table: "Recipients",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Recipients",
                table: "Recipients",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "FriendList",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    FriendId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FriendList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FriendList_User_FriendId",
                        column: x => x.FriendId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FriendList_FriendId",
                table: "FriendList",
                column: "FriendId");

            migrationBuilder.AddForeignKey(
                name: "FK_InboxRecipient_Recipients_RecipientsId",
                table: "InboxRecipient",
                column: "RecipientsId",
                principalTable: "Recipients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Recipients_User_ReceiverId",
                table: "Recipients",
                column: "ReceiverId",
                principalTable: "User",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InboxRecipient_Recipients_RecipientsId",
                table: "InboxRecipient");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipients_User_ReceiverId",
                table: "Recipients");

            migrationBuilder.DropTable(
                name: "FriendList");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Recipients",
                table: "Recipients");

            migrationBuilder.RenameTable(
                name: "Recipients",
                newName: "Recipient");

            migrationBuilder.RenameIndex(
                name: "IX_Recipients_ReceiverId",
                table: "Recipient",
                newName: "IX_Recipient_ReceiverId");

            migrationBuilder.AlterColumn<string>(
                name: "ReceiverId",
                table: "Recipient",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Recipient",
                table: "Recipient",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InboxRecipient_Recipient_RecipientsId",
                table: "InboxRecipient",
                column: "RecipientsId",
                principalTable: "Recipient",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Recipient_User_ReceiverId",
                table: "Recipient",
                column: "ReceiverId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
