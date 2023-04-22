using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace login2.Migrations
{
    /// <inheritdoc />
    public partial class AylikAidatAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SikayetEdilenId",
                table: "sikayetler");

            migrationBuilder.DropColumn(
                name: "Aidat",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "AylikAidat",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Aidat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AylikAidat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AylikAidat_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsersViewModel",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DaireNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Aidat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TelefonNumarasi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersViewModel", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AylikAidat_UserId",
                table: "AylikAidat",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AylikAidat");

            migrationBuilder.DropTable(
                name: "UsersViewModel");

            migrationBuilder.AddColumn<string>(
                name: "SikayetEdilenId",
                table: "sikayetler",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Aidat",
                table: "AspNetUsers",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
