using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IndieWorld.Migrations
{
    /// <inheritdoc />
    public partial class PromotionUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LogoUrl",
                table: "Promotions",
                newName: "Logo");

            migrationBuilder.AlterColumn<string>(
                name: "ShowTime",
                table: "Shows",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "ShowName",
                table: "Shows",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "ShowImage",
                table: "Shows",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "Shows",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Promotions",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "Off Center Wrestling is known for its innovative and unconventional approach to professional wrestling, based in Nashville, TN. Established in 2020, OCW quickly made a name for itself with its unique blend of high-energy performances and creative storytelling.");

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "Game Changer Wrestling, founded in 1999, is renowned for its hardcore style and innovative matches. Based in New Jersey, GCW has garnered a cult following due to its willingness to push the boundaries of traditional wrestling.");

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "Combat Zone Wrestling, also known as CZW, is famous for its ultraviolent wrestling style and deathmatch events. Founded in 1999 and based in Philadelphia, PA, CZW is a staple in the hardcore wrestling scene.");

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 4,
                column: "Description",
                value: "Pro Wrestling Guerilla, commonly referred to as PWG, is based in Los Angeles, CA, and is known for its high-caliber independent wrestling events. Since its establishment in 2003, PWG has been a launching pad for many top wrestlers in the industry. Currently, PWG is on hiatus.");

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 5,
                column: "Description",
                value: "Beyond Wrestling, established in 2009, is a leading independent wrestling promotion based in Worcester, MA. Known for its unique fan engagement and innovative events, Beyond Wrestling has become a hub for top indie wrestling talent.");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Promotions");

            migrationBuilder.RenameColumn(
                name: "Logo",
                table: "Promotions",
                newName: "LogoUrl");

            migrationBuilder.AlterColumn<string>(
                name: "ShowTime",
                table: "Shows",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ShowName",
                table: "Shows",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ShowImage",
                table: "Shows",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "Shows",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }
    }
}
