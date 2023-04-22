using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace login2.Migrations
{
    /// <inheritdoc />
    public partial class UsersViewModelEdited : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "UsersViewModel",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_UsersViewModel_UserId",
                table: "UsersViewModel",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersViewModel_AspNetUsers_UserId",
                table: "UsersViewModel",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersViewModel_AspNetUsers_UserId",
                table: "UsersViewModel");

            migrationBuilder.DropIndex(
                name: "IX_UsersViewModel_UserId",
                table: "UsersViewModel");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UsersViewModel");
        }
    }
}
