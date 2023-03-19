using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MH.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addnewtables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdated",
                table: "State",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 3, 8, 5, 36, 42, 495, DateTimeKind.Utc).AddTicks(7617),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 3, 3, 11, 58, 5, 181, DateTimeKind.Utc).AddTicks(5767));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "State",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 8, 5, 36, 42, 495, DateTimeKind.Utc).AddTicks(6357),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2023, 3, 3, 11, 58, 5, 181, DateTimeKind.Utc).AddTicks(4669));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdated",
                table: "Country",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 3, 8, 5, 36, 42, 416, DateTimeKind.Utc).AddTicks(4642),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 3, 3, 11, 58, 5, 133, DateTimeKind.Utc).AddTicks(4585));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Country",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 8, 5, 36, 42, 416, DateTimeKind.Utc).AddTicks(2756),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2023, 3, 3, 11, 58, 5, 133, DateTimeKind.Utc).AddTicks(3234));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdated",
                table: "City",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 3, 8, 5, 36, 42, 413, DateTimeKind.Utc).AddTicks(8171),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 3, 3, 11, 58, 5, 132, DateTimeKind.Utc).AddTicks(9331));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "City",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 8, 5, 36, 42, 413, DateTimeKind.Utc).AddTicks(5841),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2023, 3, 3, 11, 58, 5, 132, DateTimeKind.Utc).AddTicks(7422));

            migrationBuilder.CreateTable(
                name: "Collaborator",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collaborator", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lyrics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lyrics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Song",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Song", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SongCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SongCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserProfileImage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ContentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Data = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfileImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserProfileImage_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserProfileImage_UserId",
                table: "UserProfileImage",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Collaborator");

            migrationBuilder.DropTable(
                name: "Lyrics");

            migrationBuilder.DropTable(
                name: "Song");

            migrationBuilder.DropTable(
                name: "SongCategory");

            migrationBuilder.DropTable(
                name: "UserProfileImage");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdated",
                table: "State",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 3, 3, 11, 58, 5, 181, DateTimeKind.Utc).AddTicks(5767),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 3, 8, 5, 36, 42, 495, DateTimeKind.Utc).AddTicks(7617));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "State",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 3, 11, 58, 5, 181, DateTimeKind.Utc).AddTicks(4669),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2023, 3, 8, 5, 36, 42, 495, DateTimeKind.Utc).AddTicks(6357));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdated",
                table: "Country",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 3, 3, 11, 58, 5, 133, DateTimeKind.Utc).AddTicks(4585),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 3, 8, 5, 36, 42, 416, DateTimeKind.Utc).AddTicks(4642));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Country",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 3, 11, 58, 5, 133, DateTimeKind.Utc).AddTicks(3234),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2023, 3, 8, 5, 36, 42, 416, DateTimeKind.Utc).AddTicks(2756));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdated",
                table: "City",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 3, 3, 11, 58, 5, 132, DateTimeKind.Utc).AddTicks(9331),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 3, 8, 5, 36, 42, 413, DateTimeKind.Utc).AddTicks(8171));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "City",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 3, 11, 58, 5, 132, DateTimeKind.Utc).AddTicks(7422),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2023, 3, 8, 5, 36, 42, 413, DateTimeKind.Utc).AddTicks(5841));
        }
    }
}
