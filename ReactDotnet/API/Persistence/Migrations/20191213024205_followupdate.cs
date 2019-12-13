using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class followupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserFollowings_AspNetUsers_ObserverId",
                table: "UserFollowings");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFollowings_AspNetUsers_TergetId",
                table: "UserFollowings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserFollowings",
                table: "UserFollowings");

            migrationBuilder.RenameTable(
                name: "UserFollowings",
                newName: "Followings");

            migrationBuilder.RenameIndex(
                name: "IX_UserFollowings_ObserverId",
                table: "Followings",
                newName: "IX_Followings_ObserverId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Followings",
                table: "Followings",
                columns: new[] { "TergetId", "ObserverId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Followings_AspNetUsers_ObserverId",
                table: "Followings",
                column: "ObserverId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Followings_AspNetUsers_TergetId",
                table: "Followings",
                column: "TergetId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Followings_AspNetUsers_ObserverId",
                table: "Followings");

            migrationBuilder.DropForeignKey(
                name: "FK_Followings_AspNetUsers_TergetId",
                table: "Followings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Followings",
                table: "Followings");

            migrationBuilder.RenameTable(
                name: "Followings",
                newName: "UserFollowings");

            migrationBuilder.RenameIndex(
                name: "IX_Followings_ObserverId",
                table: "UserFollowings",
                newName: "IX_UserFollowings_ObserverId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserFollowings",
                table: "UserFollowings",
                columns: new[] { "TergetId", "ObserverId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserFollowings_AspNetUsers_ObserverId",
                table: "UserFollowings",
                column: "ObserverId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFollowings_AspNetUsers_TergetId",
                table: "UserFollowings",
                column: "TergetId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
