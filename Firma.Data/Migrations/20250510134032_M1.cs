using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace Firma.Data.Migrations
{
    /// <inheritdoc />
    public partial class M1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aktualnosc",
                columns: table => new
                {
                    IdAktualnosci = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LinkTytul = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Tytul = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Tresc = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Pozycja = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aktualnosc", x => x.IdAktualnosci);
                });

            migrationBuilder.CreateTable(
                name: "Cukiernia",
                columns: table => new
                {
                    IdCukierni = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Adres = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    GodzinyOtwarcia = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    FotoUrl = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cukiernia", x => x.IdCukierni);
                });

            migrationBuilder.CreateTable(
                name: "Kategoria",
                columns: table => new
                {
                    IdKategorii = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(MAX)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategoria", x => x.IdKategorii);
                });

            migrationBuilder.CreateTable(
                name: "Klient",
                columns: table => new
                {
                    IdKlienta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Nazwisko = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Adres = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DataRejestracji = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klient", x => x.IdKlienta);
                });

            migrationBuilder.CreateTable(
                name: "Pomoc",
                columns: table => new
                {
                    IdPomocy = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LinkTytul = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Tytul = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Tresc = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Pozycja = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pomoc", x => x.IdPomocy);
                });

            migrationBuilder.CreateTable(
                name: "Skladnik",
                columns: table => new
                {
                    IdSkladnika = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Jednostka = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skladnik", x => x.IdSkladnika);
                });

            migrationBuilder.CreateTable(
                name: "Strona",
                columns: table => new
                {
                    IdStrony = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LinkTytul = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Tytul = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Tresc = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Pozycja = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Strona", x => x.IdStrony);
                });

            migrationBuilder.CreateTable(
                name: "Produkt",
                columns: table => new
                {
                    IdProduktu = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Cena = table.Column<decimal>(type: "money", nullable: false),
                    Dostepnosc = table.Column<bool>(type: "bit", nullable: false),
                    IdKategorii = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produkt", x => x.IdProduktu);
                    table.ForeignKey(
                        name: "FK_Produkt_Kategoria_IdKategorii",
                        column: x => x.IdKategorii,
                        principalTable: "Kategoria",
                        principalColumn: "IdKategorii",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Zamowienie",
                columns: table => new
                {
                    IdZamowienia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numer = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Kwota = table.Column<decimal>(type: "money", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DataZamowienia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataOdbioru = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Uwagi = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    IdKlienta = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zamowienie", x => x.IdZamowienia);
                    table.ForeignKey(
                        name: "FK_Zamowienie_Klient_IdKlienta",
                        column: x => x.IdKlienta,
                        principalTable: "Klient",
                        principalColumn: "IdKlienta",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProduktSkladnik",
                columns: table => new
                {
                    IdProduktSkladniki = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IloscWymagana = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IdProduktu = table.Column<int>(type: "int", nullable: false),
                    IdSkladnika = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProduktSkladnik", x => x.IdProduktSkladniki);
                    table.ForeignKey(
                        name: "FK_ProduktSkladnik_Produkt_IdProduktu",
                        column: x => x.IdProduktu,
                        principalTable: "Produkt",
                        principalColumn: "IdProduktu",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProduktSkladnik_Skladnik_IdSkladnika",
                        column: x => x.IdSkladnika,
                        principalTable: "Skladnik",
                        principalColumn: "IdSkladnika",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reklamacja",
                columns: table => new
                {
                    IdReklamacji = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Opis = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    DataZgloszenia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdZamowienia = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reklamacja", x => x.IdReklamacji);
                    table.ForeignKey(
                        name: "FK_Reklamacja_Zamowienie_IdZamowienia",
                        column: x => x.IdZamowienia,
                        principalTable: "Zamowienie",
                        principalColumn: "IdZamowienia",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produkt_IdKategorii",
                table: "Produkt",
                column: "IdKategorii");

            migrationBuilder.CreateIndex(
                name: "IX_ProduktSkladnik_IdProduktu",
                table: "ProduktSkladnik",
                column: "IdProduktu");

            migrationBuilder.CreateIndex(
                name: "IX_ProduktSkladnik_IdSkladnika",
                table: "ProduktSkladnik",
                column: "IdSkladnika");

            migrationBuilder.CreateIndex(
                name: "IX_Reklamacja_IdZamowienia",
                table: "Reklamacja",
                column: "IdZamowienia");

            migrationBuilder.CreateIndex(
                name: "IX_Zamowienie_IdKlienta",
                table: "Zamowienie",
                column: "IdKlienta");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aktualnosc");

            migrationBuilder.DropTable(
                name: "Cukiernia");

            migrationBuilder.DropTable(
                name: "Pomoc");

            migrationBuilder.DropTable(
                name: "ProduktSkladnik");

            migrationBuilder.DropTable(
                name: "Reklamacja");

            migrationBuilder.DropTable(
                name: "Strona");

            migrationBuilder.DropTable(
                name: "Produkt");

            migrationBuilder.DropTable(
                name: "Skladnik");

            migrationBuilder.DropTable(
                name: "Zamowienie");

            migrationBuilder.DropTable(
                name: "Kategoria");

            migrationBuilder.DropTable(
                name: "Klient");
        }
    }
}
