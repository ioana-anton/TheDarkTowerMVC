using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheDarkTowerMVC.Migrations
{
    public partial class FriendListFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FriendList_User_FriendId",
                table: "FriendList");

            migrationBuilder.DropIndex(
                name: "IX_FriendList_FriendId",
                table: "FriendList");

            migrationBuilder.DropColumn(
                name: "FriendId",
                table: "FriendList");

            migrationBuilder.CreateTable(
                name: "FriendListUser",
                columns: table => new
                {
                    FriendsId = table.Column<string>(type: "text", nullable: false),
                    UsersId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FriendListUser", x => new { x.FriendsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_FriendListUser_FriendList_FriendsId",
                        column: x => x.FriendsId,
                        principalTable: "FriendList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FriendListUser_User_UsersId",
                        column: x => x.UsersId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FriendListUser_UsersId",
                table: "FriendListUser",
                column: "UsersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FriendListUser");

            migrationBuilder.AddColumn<string>(
                name: "FriendId",
                table: "FriendList",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_FriendList_FriendId",
                table: "FriendList",
                column: "FriendId");

            migrationBuilder.AddForeignKey(
                name: "FK_FriendList_User_FriendId",
                table: "FriendList",
                column: "FriendId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
