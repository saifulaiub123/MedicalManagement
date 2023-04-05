using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MH.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddPositionFkApplicationUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Position_CreatedBy",
                table: "Position",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Position_UpdatedBy",
                table: "Position",
                column: "UpdatedBy");

            migrationBuilder.AddForeignKey(
                name: "FK_Position_AspNetUsers_CreatedBy",
                table: "Position",
                column: "CreatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Position_AspNetUsers_UpdatedBy",
                table: "Position",
                column: "UpdatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Position_AspNetUsers_CreatedBy",
                table: "Position");

            migrationBuilder.DropForeignKey(
                name: "FK_Position_AspNetUsers_UpdatedBy",
                table: "Position");

            migrationBuilder.DropIndex(
                name: "IX_Position_CreatedBy",
                table: "Position");

            migrationBuilder.DropIndex(
                name: "IX_Position_UpdatedBy",
                table: "Position");
        }
    }
}
