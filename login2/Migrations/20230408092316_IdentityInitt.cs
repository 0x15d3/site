using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace login2.Migrations
{
    /// <inheritdoc />
    public partial class IdentityInitt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Aidat",
                table: "AspNetUsers",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "DaireNo",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TelefonNumarasi",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Aidat",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DaireNo",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TelefonNumarasi",
                table: "AspNetUsers");
        }
    }
}
