using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebSerwisRowerowy.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Klienci",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nazwisko = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NrTelefonu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NIP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Firma = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Miasto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KodPocztowy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klienci", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MetodPlatnosci",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetodPlatnosci", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pracownicy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nazwisko = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pesel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NrTelefonu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataRozpoczecia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataZakonczenia = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pracownicy", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Uslugi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CenaNetto = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PodatekVAT = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uslugi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Zlecenia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PracownikID = table.Column<int>(type: "int", nullable: true),
                    KlientID = table.Column<int>(type: "int", nullable: false),
                    NazwaRoweru = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataPrzyjecia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataOdbioru = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CenaBrutto = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MetodPlatnosciID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zlecenia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Zlecenia_Klienci_KlientID",
                        column: x => x.KlientID,
                        principalTable: "Klienci",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Zlecenia_MetodPlatnosci_MetodPlatnosciID",
                        column: x => x.MetodPlatnosciID,
                        principalTable: "MetodPlatnosci",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Zlecenia_Pracownicy_PracownikID",
                        column: x => x.PracownikID,
                        principalTable: "Pracownicy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UslugiUzyte",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ZlecenieID = table.Column<int>(type: "int", nullable: false),
                    UslugiID = table.Column<int>(type: "int", nullable: false),
                    Ilosc = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UslugiUzyte", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UslugiUzyte_Uslugi_UslugiID",
                        column: x => x.UslugiID,
                        principalTable: "Uslugi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UslugiUzyte_Zlecenia_ZlecenieID",
                        column: x => x.ZlecenieID,
                        principalTable: "Zlecenia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UslugiUzyte_UslugiID",
                table: "UslugiUzyte",
                column: "UslugiID");

            migrationBuilder.CreateIndex(
                name: "IX_UslugiUzyte_ZlecenieID",
                table: "UslugiUzyte",
                column: "ZlecenieID");

            migrationBuilder.CreateIndex(
                name: "IX_Zlecenia_KlientID",
                table: "Zlecenia",
                column: "KlientID");

            migrationBuilder.CreateIndex(
                name: "IX_Zlecenia_MetodPlatnosciID",
                table: "Zlecenia",
                column: "MetodPlatnosciID");

            migrationBuilder.CreateIndex(
                name: "IX_Zlecenia_PracownikID",
                table: "Zlecenia",
                column: "PracownikID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "UslugiUzyte");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Uslugi");

            migrationBuilder.DropTable(
                name: "Zlecenia");

            migrationBuilder.DropTable(
                name: "Klienci");

            migrationBuilder.DropTable(
                name: "MetodPlatnosci");

            migrationBuilder.DropTable(
                name: "Pracownicy");
        }
    }
}
