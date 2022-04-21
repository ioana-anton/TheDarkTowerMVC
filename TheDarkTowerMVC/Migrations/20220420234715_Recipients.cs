using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheDarkTowerMVC.Migrations
{
    public partial class Recipients : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InboxUser");

            migrationBuilder.AddColumn<string>(
                name: "SenderId",
                table: "Inboxes",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Recipient",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    ReceiverId = table.Column<string>(type: "text", nullable: false),
                    InboxId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipient", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recipient_Inboxes_InboxId",
                        column: x => x.InboxId,
                        principalTable: "Inboxes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Recipient_User_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inboxes_SenderId",
                table: "Inboxes",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipient_InboxId",
                table: "Recipient",
                column: "InboxId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipient_ReceiverId",
                table: "Recipient",
                column: "ReceiverId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inboxes_User_SenderId",
                table: "Inboxes",
                column: "SenderId",
                principalTable: "User",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inboxes_User_SenderId",
                table: "Inboxes");

            migrationBuilder.DropTable(
                name: "Recipient");

            migrationBuilder.DropIndex(
                name: "IX_Inboxes_SenderId",
                table: "Inboxes");

            migrationBuilder.DropColumn(
                name: "SenderId",
                table: "Inboxes");

            migrationBuilder.CreateTable(
                name: "InboxUser",
                columns: table => new
                {
                    InboxesId = table.Column<string>(type: "text", nullable: false),
                    UsersId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InboxUser", x => new { x.InboxesId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_InboxUser_Inboxes_InboxesId",
                        column: x => x.InboxesId,
                        principalTable: "Inboxes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InboxUser_User_UsersId",
                        column: x => x.UsersId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InboxUser_UsersId",
                table: "InboxUser",
                column: "UsersId");
        }
    }
}
