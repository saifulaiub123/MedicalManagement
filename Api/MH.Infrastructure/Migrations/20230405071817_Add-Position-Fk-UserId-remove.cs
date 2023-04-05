using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MH.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddPositionFkUserIdremove : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Position_AspNetUsers_UserId",
                table: "Position");

            migrationBuilder.DropIndex(
                name: "IX_Position_UserId",
                table: "Position");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Position");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Position",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Position_UserId",
                table: "Position",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Position_AspNetUsers_UserId",
                table: "Position",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
