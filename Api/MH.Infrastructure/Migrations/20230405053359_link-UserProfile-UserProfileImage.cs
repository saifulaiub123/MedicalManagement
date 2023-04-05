using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MH.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class linkUserProfileUserProfileImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "UserProfileImage",
                newName: "UserProfileId");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "UserProfileImage",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfileImage_CreatedBy",
                table: "UserProfileImage",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfileImage_UpdatedBy",
                table: "UserProfileImage",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfileImage_UserProfileId",
                table: "UserProfileImage",
                column: "UserProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfileImage_AspNetUsers_CreatedBy",
                table: "UserProfileImage",
                column: "CreatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfileImage_AspNetUsers_UpdatedBy",
                table: "UserProfileImage",
                column: "UpdatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfileImage_UserProfile_UserProfileId",
                table: "UserProfileImage",
                column: "UserProfileId",
                principalTable: "UserProfile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProfileImage_AspNetUsers_CreatedBy",
                table: "UserProfileImage");

            migrationBuilder.DropForeignKey(
                name: "FK_UserProfileImage_AspNetUsers_UpdatedBy",
                table: "UserProfileImage");

            migrationBuilder.DropForeignKey(
                name: "FK_UserProfileImage_UserProfile_UserProfileId",
                table: "UserProfileImage");

            migrationBuilder.DropIndex(
                name: "IX_UserProfileImage_CreatedBy",
                table: "UserProfileImage");

            migrationBuilder.DropIndex(
                name: "IX_UserProfileImage_UpdatedBy",
                table: "UserProfileImage");

            migrationBuilder.DropIndex(
                name: "IX_UserProfileImage_UserProfileId",
                table: "UserProfileImage");

            migrationBuilder.RenameColumn(
                name: "UserProfileId",
                table: "UserProfileImage",
                newName: "UserId");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "UserProfileImage",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);
        }
    }
}
