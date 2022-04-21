using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheDarkTowerMVC.Migrations
{
    public partial class RecipientsFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipient_Inboxes_InboxId",
                table: "Recipient");

            migrationBuilder.DropIndex(
                name: "IX_Recipient_InboxId",
                table: "Recipient");

            migrationBuilder.DropColumn(
                name: "InboxId",
                table: "Recipient");

            migrationBuilder.CreateTable(
                name: "InboxRecipient",
                columns: table => new
                {
                    InboxId = table.Column<string>(type: "text", nullable: false),
                    RecipientsId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InboxRecipient", x => new { x.InboxId, x.RecipientsId });
                    table.ForeignKey(
                        name: "FK_InboxRecipient_Inboxes_InboxId",
                        column: x => x.InboxId,
                        principalTable: "Inboxes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InboxRecipient_Recipient_RecipientsId",
                        column: x => x.RecipientsId,
                        principalTable: "Recipient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InboxRecipient_RecipientsId",
                table: "InboxRecipient",
                column: "RecipientsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InboxRecipient");

            migrationBuilder.AddColumn<string>(
                name: "InboxId",
                table: "Recipient",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Recipient_InboxId",
                table: "Recipient",
                column: "InboxId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipient_Inboxes_InboxId",
                table: "Recipient",
                column: "InboxId",
                principalTable: "Inboxes",
                principalColumn: "Id");
        }
    }
}
