using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheDarkTowerMVC.Migrations
{
    public partial class FriendListFix2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FriendListUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FriendList",
                table: "FriendList");

            migrationBuilder.RenameTable(
                name: "FriendList",
                newName: "Friends");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Friends",
                type: "text",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Friends",
                table: "Friends",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Friends_UserId",
                table: "Friends",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Friends_User_UserId",
                table: "Friends",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Friends_User_UserId",
                table: "Friends");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Friends",
                table: "Friends");

            migrationBuilder.DropIndex(
                name: "IX_Friends_UserId",
                table: "Friends");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Friends");

            migrationBuilder.RenameTable(
                name: "Friends",
                newName: "FriendList");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FriendList",
                table: "FriendList",
                column: "Id");

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
    }
}
