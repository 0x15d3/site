using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace login2.Migrations
{
    /// <inheritdoc />
    public partial class SikayetAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "sikayetler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Konu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SikayetEdilenId = table.Column<int>(type: "int", nullable: false),
                    SikayetEdenId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SikayetText = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sikayetler", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "sikayetler");
        }
    }
}
