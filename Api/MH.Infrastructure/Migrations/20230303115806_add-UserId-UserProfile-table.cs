using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MH.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addUserIdUserProfiletable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "UserProfile",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdated",
                table: "State",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 3, 3, 11, 58, 5, 181, DateTimeKind.Utc).AddTicks(5767),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 3, 3, 11, 23, 12, 923, DateTimeKind.Utc).AddTicks(8190));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "State",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 3, 11, 58, 5, 181, DateTimeKind.Utc).AddTicks(4669),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2023, 3, 3, 11, 23, 12, 923, DateTimeKind.Utc).AddTicks(7012));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdated",
                table: "Country",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 3, 3, 11, 58, 5, 133, DateTimeKind.Utc).AddTicks(4585),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 3, 3, 11, 23, 12, 871, DateTimeKind.Utc).AddTicks(5343));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Country",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 3, 11, 58, 5, 133, DateTimeKind.Utc).AddTicks(3234),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2023, 3, 3, 11, 23, 12, 871, DateTimeKind.Utc).AddTicks(3907));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdated",
                table: "City",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 3, 3, 11, 58, 5, 132, DateTimeKind.Utc).AddTicks(9331),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 3, 3, 11, 23, 12, 871, DateTimeKind.Utc).AddTicks(913));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "City",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 3, 11, 58, 5, 132, DateTimeKind.Utc).AddTicks(7422),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2023, 3, 3, 11, 23, 12, 870, DateTimeKind.Utc).AddTicks(8871));

            migrationBuilder.CreateIndex(
                name: "IX_UserProfile_UserId",
                table: "UserProfile",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfile_AspNetUsers_UserId",
                table: "UserProfile",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProfile_AspNetUsers_UserId",
                table: "UserProfile");

            migrationBuilder.DropIndex(
                name: "IX_UserProfile_UserId",
                table: "UserProfile");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserProfile");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdated",
                table: "State",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 3, 3, 11, 23, 12, 923, DateTimeKind.Utc).AddTicks(8190),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 3, 3, 11, 58, 5, 181, DateTimeKind.Utc).AddTicks(5767));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "State",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 3, 11, 23, 12, 923, DateTimeKind.Utc).AddTicks(7012),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2023, 3, 3, 11, 58, 5, 181, DateTimeKind.Utc).AddTicks(4669));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdated",
                table: "Country",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 3, 3, 11, 23, 12, 871, DateTimeKind.Utc).AddTicks(5343),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 3, 3, 11, 58, 5, 133, DateTimeKind.Utc).AddTicks(4585));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Country",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 3, 11, 23, 12, 871, DateTimeKind.Utc).AddTicks(3907),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2023, 3, 3, 11, 58, 5, 133, DateTimeKind.Utc).AddTicks(3234));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdated",
                table: "City",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 3, 3, 11, 23, 12, 871, DateTimeKind.Utc).AddTicks(913),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 3, 3, 11, 58, 5, 132, DateTimeKind.Utc).AddTicks(9331));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "City",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 3, 11, 23, 12, 870, DateTimeKind.Utc).AddTicks(8871),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2023, 3, 3, 11, 58, 5, 132, DateTimeKind.Utc).AddTicks(7422));
        }
    }
}
