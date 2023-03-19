using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MH.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class modifyproperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "fileName",
                table: "UserProfileImage",
                newName: "FileName");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdated",
                table: "State",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 3, 8, 5, 39, 47, 366, DateTimeKind.Utc).AddTicks(3698),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 3, 8, 5, 36, 42, 495, DateTimeKind.Utc).AddTicks(7617));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "State",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 8, 5, 39, 47, 366, DateTimeKind.Utc).AddTicks(2299),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2023, 3, 8, 5, 36, 42, 495, DateTimeKind.Utc).AddTicks(6357));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdated",
                table: "Country",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 3, 8, 5, 39, 47, 308, DateTimeKind.Utc).AddTicks(5823),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 3, 8, 5, 36, 42, 416, DateTimeKind.Utc).AddTicks(4642));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Country",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 8, 5, 39, 47, 308, DateTimeKind.Utc).AddTicks(4345),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2023, 3, 8, 5, 36, 42, 416, DateTimeKind.Utc).AddTicks(2756));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdated",
                table: "City",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 3, 8, 5, 39, 47, 306, DateTimeKind.Utc).AddTicks(4001),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 3, 8, 5, 36, 42, 413, DateTimeKind.Utc).AddTicks(8171));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "City",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 8, 5, 39, 47, 306, DateTimeKind.Utc).AddTicks(2041),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2023, 3, 8, 5, 36, 42, 413, DateTimeKind.Utc).AddTicks(5841));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FileName",
                table: "UserProfileImage",
                newName: "fileName");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdated",
                table: "State",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 3, 8, 5, 36, 42, 495, DateTimeKind.Utc).AddTicks(7617),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 3, 8, 5, 39, 47, 366, DateTimeKind.Utc).AddTicks(3698));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "State",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 8, 5, 36, 42, 495, DateTimeKind.Utc).AddTicks(6357),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2023, 3, 8, 5, 39, 47, 366, DateTimeKind.Utc).AddTicks(2299));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdated",
                table: "Country",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 3, 8, 5, 36, 42, 416, DateTimeKind.Utc).AddTicks(4642),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 3, 8, 5, 39, 47, 308, DateTimeKind.Utc).AddTicks(5823));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Country",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 8, 5, 36, 42, 416, DateTimeKind.Utc).AddTicks(2756),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2023, 3, 8, 5, 39, 47, 308, DateTimeKind.Utc).AddTicks(4345));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdated",
                table: "City",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 3, 8, 5, 36, 42, 413, DateTimeKind.Utc).AddTicks(8171),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 3, 8, 5, 39, 47, 306, DateTimeKind.Utc).AddTicks(4001));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "City",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 8, 5, 36, 42, 413, DateTimeKind.Utc).AddTicks(5841),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2023, 3, 8, 5, 39, 47, 306, DateTimeKind.Utc).AddTicks(2041));
        }
    }
}
