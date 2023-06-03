using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleGlicemia_003.Migrations
{
    public partial class Creating_DBs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GLICEMIAS",
                columns: table => new
                {
                    GlicemiaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GlicemiaMedida = table.Column<int>(type: "int", nullable: true),
                    DataMedicao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HoraMedicao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataAplicacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HoraAplicacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DoseRegular = table.Column<int>(type: "int", nullable: true),
                    DoseAjuste = table.Column<int>(type: "int", nullable: true),
                    Observacao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GLICEMIAS", x => x.GlicemiaID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GLICEMIAS");
        }
    }
}
