using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Site.Migrations
{
    /// <inheritdoc />
    public partial class DemoInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Aidat",
                table: "AylikAidatlar");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "AylikAidatlar",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<decimal>(
                name: "Tutar",
                table: "AylikAidatlar",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<double>(
                name: "Aidat",
                table: "AspNetUsers",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateIndex(
                name: "IX_AylikAidatlar_UserId",
                table: "AylikAidatlar",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AylikAidatlar_AspNetUsers_UserId",
                table: "AylikAidatlar",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AylikAidatlar_AspNetUsers_UserId",
                table: "AylikAidatlar");

            migrationBuilder.DropIndex(
                name: "IX_AylikAidatlar_UserId",
                table: "AylikAidatlar");

            migrationBuilder.DropColumn(
                name: "Tutar",
                table: "AylikAidatlar");

            migrationBuilder.DropColumn(
                name: "Aidat",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "AylikAidatlar",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<double>(
                name: "Aidat",
                table: "AylikAidatlar",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
