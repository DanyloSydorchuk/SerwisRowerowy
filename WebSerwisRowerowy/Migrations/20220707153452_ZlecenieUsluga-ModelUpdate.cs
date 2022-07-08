using Microsoft.EntityFrameworkCore.Migrations;

namespace WebSerwisRowerowy.Migrations
{
    public partial class ZlecenieUslugaModelUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UslugaZlecenie",
                columns: table => new
                {
                    UslugiId = table.Column<int>(type: "int", nullable: false),
                    ZleceniaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UslugaZlecenie", x => new { x.UslugiId, x.ZleceniaId });
                    table.ForeignKey(
                        name: "FK_UslugaZlecenie_Uslugi_UslugiId",
                        column: x => x.UslugiId,
                        principalTable: "Uslugi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UslugaZlecenie_Zlecenia_ZleceniaId",
                        column: x => x.ZleceniaId,
                        principalTable: "Zlecenia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UslugaZlecenie_ZleceniaId",
                table: "UslugaZlecenie",
                column: "ZleceniaId");
        }
    }
}
