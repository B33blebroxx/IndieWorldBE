using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IndieWorld.Migrations
{
    /// <inheritdoc />
    public partial class PerformerSocialsAddition : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Instagram",
                table: "Performers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "X",
                table: "Performers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Performers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Instagram", "X" },
                values: new object[] { "https://www.instagram.com/thekingnickgage", "https://twitter.com/thekingnickgage" });

            migrationBuilder.UpdateData(
                table: "Performers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Image", "Instagram", "X" },
                values: new object[] { "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT3g_1QeUosxEunuSGpzUj_fnGO-RccLNsUjQ&s", "https://www.instagram.com/effylives", "https://twitter.com/effylives" });

            migrationBuilder.UpdateData(
                table: "Performers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Instagram", "X" },
                values: new object[] { "https://www.instagram.com/warhorsewrestling", "https://twitter.com/JPWARHORSE" });

            migrationBuilder.UpdateData(
                table: "Performers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Instagram", "X" },
                values: new object[] { "https://www.instagram.com/alliekatch", "https://twitter.com/alliekatch" });

            migrationBuilder.UpdateData(
                table: "Performers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Instagram", "X" },
                values: new object[] { "https://www.instagram.com/danhousenad", "https://twitter.com/danhousenad" });

            migrationBuilder.UpdateData(
                table: "Performers",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Instagram", "X" },
                values: new object[] { "https://www.instagram.com/bryceremsburg", "https://twitter.com/dabryceisright" });

            migrationBuilder.UpdateData(
                table: "Performers",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Instagram", "X" },
                values: new object[] { "https://www.instagram.com/daveprazak", "https://twitter.com/daveprazak" });

            migrationBuilder.UpdateData(
                table: "Performers",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Instagram", "X" },
                values: new object[] { "https://www.instagram.com/lenny_leonard", "https://twitter.com/dragonlenny" });

            migrationBuilder.UpdateData(
                table: "Performers",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Instagram", "X" },
                values: new object[] { "https://www.instagram.com/itsvedatime", "https://twitter.com/itsvedatime" });

            migrationBuilder.UpdateData(
                table: "Performers",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Instagram", "X" },
                values: new object[] { "https://www.instagram.com/aubreysmash", "https://twitter.com/RefAubrey" });

            migrationBuilder.UpdateData(
                table: "Performers",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Instagram", "X" },
                values: new object[] { "https://www.instagram.com/ogkevingill", "https://twitter.com/ogkevingill" });

            migrationBuilder.UpdateData(
                table: "Performers",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Instagram", "X" },
                values: new object[] { "https://www.instagram.com/martyelias", "https://twitter.com/martyelias1967" });

            migrationBuilder.UpdateData(
                table: "Performers",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Instagram", "X" },
                values: new object[] { "https://www.instagram.com/shutup_excalibur", "https://twitter.com/shutup_excalibur" });

            migrationBuilder.UpdateData(
                table: "Performers",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Instagram", "X" },
                values: new object[] { "https://www.instagram.com/tonydeppen", "https://twitter.com/tonydeppen" });

            migrationBuilder.UpdateData(
                table: "Performers",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Instagram", "X" },
                values: new object[] { "https://www.instagram.com/mancewarner", "https://twitter.com/ManceWarner" });

            migrationBuilder.UpdateData(
                table: "Performers",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Instagram", "X" },
                values: new object[] { "https://www.instagram.com/themattcardona", "https://twitter.com/TheMattCardona" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Instagram",
                table: "Performers");

            migrationBuilder.DropColumn(
                name: "X",
                table: "Performers");

            migrationBuilder.UpdateData(
                table: "Performers",
                keyColumn: "Id",
                keyValue: 2,
                column: "Image",
                value: "https://static.wikia.nocookie.net/prowrestling/images/4/49/Effy-new-render.jpg/revision/latest?cb=20200513165511");
        }
    }
}
