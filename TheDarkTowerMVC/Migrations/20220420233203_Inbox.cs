using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheDarkTowerMVC.Migrations
{
    public partial class Inbox : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Inboxes",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Message = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inboxes", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InboxUser");

            migrationBuilder.DropTable(
                name: "Inboxes");
        }
    }
}
