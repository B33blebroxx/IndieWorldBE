using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IndieWorld.Migrations
{
    /// <inheritdoc />
    public partial class PromotionPicUpdate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PromotionPic_Promotions_PromotionId",
                table: "PromotionPic");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PromotionPic",
                table: "PromotionPic");

            migrationBuilder.RenameTable(
                name: "PromotionPic",
                newName: "PromotionPics");

            migrationBuilder.RenameIndex(
                name: "IX_PromotionPic_PromotionId",
                table: "PromotionPics",
                newName: "IX_PromotionPics_PromotionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PromotionPics",
                table: "PromotionPics",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PromotionPics_Promotions_PromotionId",
                table: "PromotionPics",
                column: "PromotionId",
                principalTable: "Promotions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PromotionPics_Promotions_PromotionId",
                table: "PromotionPics");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PromotionPics",
                table: "PromotionPics");

            migrationBuilder.RenameTable(
                name: "PromotionPics",
                newName: "PromotionPic");

            migrationBuilder.RenameIndex(
                name: "IX_PromotionPics_PromotionId",
                table: "PromotionPic",
                newName: "IX_PromotionPic_PromotionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PromotionPic",
                table: "PromotionPic",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PromotionPic_Promotions_PromotionId",
                table: "PromotionPic",
                column: "PromotionId",
                principalTable: "Promotions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
