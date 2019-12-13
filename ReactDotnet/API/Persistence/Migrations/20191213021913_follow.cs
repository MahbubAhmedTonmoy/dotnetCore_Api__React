using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class follow : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserFollowings",
                columns: table => new
                {
                    ObserverId = table.Column<string>(nullable: false),
                    TergetId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFollowings", x => new { x.TergetId, x.ObserverId });
                    table.ForeignKey(
                        name: "FK_UserFollowings_AspNetUsers_ObserverId",
                        column: x => x.ObserverId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserFollowings_AspNetUsers_TergetId",
                        column: x => x.TergetId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserFollowings_ObserverId",
                table: "UserFollowings",
                column: "ObserverId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserFollowings");
        }
    }
}
