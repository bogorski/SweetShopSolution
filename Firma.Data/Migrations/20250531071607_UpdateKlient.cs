using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Firma.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateKlient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IdentityUserId",
                table: "Klient",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Klient_IdentityUserId",
                table: "Klient",
                column: "IdentityUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Klient_AspNetUsers_IdentityUserId",
                table: "Klient",
                column: "IdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Klient_AspNetUsers_IdentityUserId",
                table: "Klient");

            migrationBuilder.DropIndex(
                name: "IX_Klient_IdentityUserId",
                table: "Klient");

            migrationBuilder.DropColumn(
                name: "IdentityUserId",
                table: "Klient");
        }
    }
}
