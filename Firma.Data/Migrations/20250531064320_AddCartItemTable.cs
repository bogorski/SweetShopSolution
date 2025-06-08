using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Firma.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddCartItemTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Koszyk",
                columns: table => new
                {
                    IdKoszyka = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdProduktu = table.Column<int>(type: "int", nullable: false),
                    IdKlienta = table.Column<int>(type: "int", nullable: false),
                    Ilosc = table.Column<int>(type: "int", nullable: false),
                    Uwagi = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    DataDodania = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Koszyk", x => x.IdKoszyka);
                    table.ForeignKey(
                        name: "FK_Koszyk_Klient_IdKlienta",
                        column: x => x.IdKlienta,
                        principalTable: "Klient",
                        principalColumn: "IdKlienta",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Koszyk_Produkt_IdProduktu",
                        column: x => x.IdProduktu,
                        principalTable: "Produkt",
                        principalColumn: "IdProduktu",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ZamowieniePozycja",
                columns: table => new
                {
                    IdZamowieniePozycja = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdZamowienia = table.Column<int>(type: "int", nullable: false),
                    IdProduktu = table.Column<int>(type: "int", nullable: false),
                    Ilosc = table.Column<int>(type: "int", nullable: false),
                    CenaJednostkowa = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZamowieniePozycja", x => x.IdZamowieniePozycja);
                    table.ForeignKey(
                        name: "FK_ZamowieniePozycja_Produkt_IdProduktu",
                        column: x => x.IdProduktu,
                        principalTable: "Produkt",
                        principalColumn: "IdProduktu",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ZamowieniePozycja_Zamowienie_IdZamowienia",
                        column: x => x.IdZamowienia,
                        principalTable: "Zamowienie",
                        principalColumn: "IdZamowienia",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Koszyk_IdKlienta",
                table: "Koszyk",
                column: "IdKlienta");

            migrationBuilder.CreateIndex(
                name: "IX_Koszyk_IdProduktu",
                table: "Koszyk",
                column: "IdProduktu");

            migrationBuilder.CreateIndex(
                name: "IX_ZamowieniePozycja_IdProduktu",
                table: "ZamowieniePozycja",
                column: "IdProduktu");

            migrationBuilder.CreateIndex(
                name: "IX_ZamowieniePozycja_IdZamowienia",
                table: "ZamowieniePozycja",
                column: "IdZamowienia");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Koszyk");

            migrationBuilder.DropTable(
                name: "ZamowieniePozycja");
        }
    }
}
