using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MH.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateUserProfiletable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdated",
                table: "State",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 3, 3, 11, 23, 12, 923, DateTimeKind.Utc).AddTicks(8190),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 3, 3, 10, 27, 48, 676, DateTimeKind.Utc).AddTicks(5418));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "State",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 3, 11, 23, 12, 923, DateTimeKind.Utc).AddTicks(7012),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2023, 3, 3, 10, 27, 48, 676, DateTimeKind.Utc).AddTicks(4196));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdated",
                table: "Country",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 3, 3, 11, 23, 12, 871, DateTimeKind.Utc).AddTicks(5343),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 3, 3, 10, 27, 48, 629, DateTimeKind.Utc).AddTicks(7119));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Country",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 3, 11, 23, 12, 871, DateTimeKind.Utc).AddTicks(3907),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2023, 3, 3, 10, 27, 48, 629, DateTimeKind.Utc).AddTicks(6062));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdated",
                table: "City",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 3, 3, 11, 23, 12, 871, DateTimeKind.Utc).AddTicks(913),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 3, 3, 10, 27, 48, 629, DateTimeKind.Utc).AddTicks(3607));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "City",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 3, 11, 23, 12, 870, DateTimeKind.Utc).AddTicks(8871),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2023, 3, 3, 10, 27, 48, 629, DateTimeKind.Utc).AddTicks(2213));

            migrationBuilder.CreateTable(
                name: "UserProfile",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    StateId = table.Column<int>(type: "int", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address1 = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Address2 = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserProfile_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserProfile_AspNetUsers_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserProfile_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserProfile_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserProfile_State_StateId",
                        column: x => x.StateId,
                        principalTable: "State",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserProfile_CityId",
                table: "UserProfile",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfile_CountryId",
                table: "UserProfile",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfile_CreatedBy",
                table: "UserProfile",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfile_StateId",
                table: "UserProfile",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfile_UpdatedBy",
                table: "UserProfile",
                column: "UpdatedBy");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserProfile");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdated",
                table: "State",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 3, 3, 10, 27, 48, 676, DateTimeKind.Utc).AddTicks(5418),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 3, 3, 11, 23, 12, 923, DateTimeKind.Utc).AddTicks(8190));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "State",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 3, 10, 27, 48, 676, DateTimeKind.Utc).AddTicks(4196),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2023, 3, 3, 11, 23, 12, 923, DateTimeKind.Utc).AddTicks(7012));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdated",
                table: "Country",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 3, 3, 10, 27, 48, 629, DateTimeKind.Utc).AddTicks(7119),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 3, 3, 11, 23, 12, 871, DateTimeKind.Utc).AddTicks(5343));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Country",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 3, 10, 27, 48, 629, DateTimeKind.Utc).AddTicks(6062),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2023, 3, 3, 11, 23, 12, 871, DateTimeKind.Utc).AddTicks(3907));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdated",
                table: "City",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 3, 3, 10, 27, 48, 629, DateTimeKind.Utc).AddTicks(3607),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 3, 3, 11, 23, 12, 871, DateTimeKind.Utc).AddTicks(913));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "City",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 3, 10, 27, 48, 629, DateTimeKind.Utc).AddTicks(2213),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2023, 3, 3, 11, 23, 12, 870, DateTimeKind.Utc).AddTicks(8871));
        }
    }
}
