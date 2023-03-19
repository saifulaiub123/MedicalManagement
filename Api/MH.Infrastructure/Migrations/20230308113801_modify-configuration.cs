using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MH.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class modifyconfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdated",
                table: "State",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 3, 8, 11, 38, 0, 431, DateTimeKind.Utc).AddTicks(5116),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 3, 8, 5, 39, 47, 366, DateTimeKind.Utc).AddTicks(3698));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "State",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 8, 11, 38, 0, 431, DateTimeKind.Utc).AddTicks(3443),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2023, 3, 8, 5, 39, 47, 366, DateTimeKind.Utc).AddTicks(2299));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdated",
                table: "Country",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 3, 8, 11, 38, 0, 362, DateTimeKind.Utc).AddTicks(1930),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 3, 8, 5, 39, 47, 308, DateTimeKind.Utc).AddTicks(5823));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Country",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 8, 11, 38, 0, 361, DateTimeKind.Utc).AddTicks(9984),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2023, 3, 8, 5, 39, 47, 308, DateTimeKind.Utc).AddTicks(4345));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdated",
                table: "City",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 3, 8, 11, 38, 0, 359, DateTimeKind.Utc).AddTicks(8700),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 3, 8, 5, 39, 47, 306, DateTimeKind.Utc).AddTicks(4001));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "City",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 8, 11, 38, 0, 359, DateTimeKind.Utc).AddTicks(6515),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2023, 3, 8, 5, 39, 47, 306, DateTimeKind.Utc).AddTicks(2041));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdated",
                table: "State",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 3, 8, 5, 39, 47, 366, DateTimeKind.Utc).AddTicks(3698),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 3, 8, 11, 38, 0, 431, DateTimeKind.Utc).AddTicks(5116));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "State",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 8, 5, 39, 47, 366, DateTimeKind.Utc).AddTicks(2299),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2023, 3, 8, 11, 38, 0, 431, DateTimeKind.Utc).AddTicks(3443));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdated",
                table: "Country",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 3, 8, 5, 39, 47, 308, DateTimeKind.Utc).AddTicks(5823),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 3, 8, 11, 38, 0, 362, DateTimeKind.Utc).AddTicks(1930));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Country",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 8, 5, 39, 47, 308, DateTimeKind.Utc).AddTicks(4345),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2023, 3, 8, 11, 38, 0, 361, DateTimeKind.Utc).AddTicks(9984));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdated",
                table: "City",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 3, 8, 5, 39, 47, 306, DateTimeKind.Utc).AddTicks(4001),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 3, 8, 11, 38, 0, 359, DateTimeKind.Utc).AddTicks(8700));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "City",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 8, 5, 39, 47, 306, DateTimeKind.Utc).AddTicks(2041),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2023, 3, 8, 11, 38, 0, 359, DateTimeKind.Utc).AddTicks(6515));
        }
    }
}
