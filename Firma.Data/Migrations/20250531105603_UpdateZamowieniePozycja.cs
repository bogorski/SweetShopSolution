using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Firma.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateZamowieniePozycja : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CenaJednostkowa",
                table: "ZamowieniePozycja",
                newName: "Cena");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "Cena",
                table: "ZamowieniePozycja",
                newName: "CenaJednostkowa");
        }
    }
}
