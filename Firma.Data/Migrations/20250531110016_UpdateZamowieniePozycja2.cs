using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Firma.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateZamowieniePozycja2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ZamowieniePozycja_ZamowieniePozycja_ZamowieniePozycjaIdZamowieniePozycja",
                table: "ZamowieniePozycja");

            migrationBuilder.DropIndex(
                name: "IX_ZamowieniePozycja_ZamowieniePozycjaIdZamowieniePozycja",
                table: "ZamowieniePozycja");

            migrationBuilder.DropColumn(
                name: "ZamowieniePozycjaIdZamowieniePozycja",
                table: "ZamowieniePozycja");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ZamowieniePozycjaIdZamowieniePozycja",
                table: "ZamowieniePozycja",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ZamowieniePozycja_ZamowieniePozycjaIdZamowieniePozycja",
                table: "ZamowieniePozycja",
                column: "ZamowieniePozycjaIdZamowieniePozycja");

            migrationBuilder.AddForeignKey(
                name: "FK_ZamowieniePozycja_ZamowieniePozycja_ZamowieniePozycjaIdZamowieniePozycja",
                table: "ZamowieniePozycja",
                column: "ZamowieniePozycjaIdZamowieniePozycja",
                principalTable: "ZamowieniePozycja",
                principalColumn: "IdZamowieniePozycja");
        }
    }
}
