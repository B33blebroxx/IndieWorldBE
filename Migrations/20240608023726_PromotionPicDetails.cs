using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IndieWorld.Migrations
{
    /// <inheritdoc />
    public partial class PromotionPicDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ShowDate",
                table: "PromotionPics",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ShowName",
                table: "PromotionPics",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "PromotionPics",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ShowDate", "ShowName" },
                values: new object[] { new DateTime(2023, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rise to Glory" });

            migrationBuilder.UpdateData(
                table: "PromotionPics",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ShowDate", "ShowName" },
                values: new object[] { new DateTime(2023, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rise to Glory" });

            migrationBuilder.UpdateData(
                table: "PromotionPics",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ShowDate", "ShowName" },
                values: new object[] { new DateTime(2023, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rise to Glory" });

            migrationBuilder.UpdateData(
                table: "PromotionPics",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ShowDate", "ShowName" },
                values: new object[] { new DateTime(2023, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rise to Glory" });

            migrationBuilder.UpdateData(
                table: "PromotionPics",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ShowDate", "ShowName" },
                values: new object[] { new DateTime(2023, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rise to Glory" });

            migrationBuilder.UpdateData(
                table: "PromotionPics",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ShowDate", "ShowName" },
                values: new object[] { new DateTime(2023, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "WrestleFist" });

            migrationBuilder.UpdateData(
                table: "PromotionPics",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ShowDate", "ShowName" },
                values: new object[] { new DateTime(2023, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "WrestleFist" });

            migrationBuilder.UpdateData(
                table: "PromotionPics",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ShowDate", "ShowName" },
                values: new object[] { new DateTime(2023, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "WrestleFist" });

            migrationBuilder.UpdateData(
                table: "PromotionPics",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ShowDate", "ShowName" },
                values: new object[] { new DateTime(2023, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "WrestleFist" });

            migrationBuilder.UpdateData(
                table: "PromotionPics",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ShowDate", "ShowName" },
                values: new object[] { new DateTime(2023, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "WrestleFist" });

            migrationBuilder.UpdateData(
                table: "PromotionPics",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "ShowDate", "ShowName" },
                values: new object[] { new DateTime(2023, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Battle in the Borough" });

            migrationBuilder.UpdateData(
                table: "PromotionPics",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "ShowDate", "ShowName" },
                values: new object[] { new DateTime(2023, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Battle in the Borough" });

            migrationBuilder.UpdateData(
                table: "PromotionPics",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "ShowDate", "ShowName" },
                values: new object[] { new DateTime(2023, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Battle in the Borough" });

            migrationBuilder.UpdateData(
                table: "PromotionPics",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "ShowDate", "ShowName" },
                values: new object[] { new DateTime(2023, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Battle in the Borough" });

            migrationBuilder.UpdateData(
                table: "PromotionPics",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "ShowDate", "ShowName" },
                values: new object[] { new DateTime(2023, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Clobberin' Time" });

            migrationBuilder.UpdateData(
                table: "PromotionPics",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "ShowDate", "ShowName" },
                values: new object[] { new DateTime(2023, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Clobberin' Time" });

            migrationBuilder.UpdateData(
                table: "PromotionPics",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "ShowDate", "ShowName" },
                values: new object[] { new DateTime(2023, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Clobberin' Time" });

            migrationBuilder.UpdateData(
                table: "PromotionPics",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "ShowDate", "ShowName" },
                values: new object[] { new DateTime(2023, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Clobberin' Time" });

            migrationBuilder.UpdateData(
                table: "PromotionPics",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "ShowDate", "ShowName" },
                values: new object[] { new DateTime(2023, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Clobberin' Time" });

            migrationBuilder.UpdateData(
                table: "PromotionPics",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "ShowDate", "ShowName" },
                values: new object[] { new DateTime(2023, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Clobberin' Time" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShowDate",
                table: "PromotionPics");

            migrationBuilder.DropColumn(
                name: "ShowName",
                table: "PromotionPics");
        }
    }
}
