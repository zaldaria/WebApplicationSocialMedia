using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplicationSocialMedia.Migrations
{
    /// <inheritdoc />
    public partial class Seven : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_friendship_AspNetUsers_friendID",
                table: "friendship");

            migrationBuilder.AddForeignKey(
                name: "FK_friendship_AspNetUsers_friendID",
                table: "friendship",
                column: "friendID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_friendship_AspNetUsers_friendID",
                table: "friendship");

            migrationBuilder.AddForeignKey(
                name: "FK_friendship_AspNetUsers_friendID",
                table: "friendship",
                column: "friendID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
