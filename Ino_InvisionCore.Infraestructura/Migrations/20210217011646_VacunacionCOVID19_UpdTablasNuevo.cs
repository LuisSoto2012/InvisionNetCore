using Microsoft.EntityFrameworkCore.Migrations;

namespace Ino_InvisionCore.Infraestructura.Migrations
{
    public partial class VacunacionCOVID19_UpdTablasNuevo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "PrimeraDosisHora",
            //    table: "VacunacionCOVID19");

            //migrationBuilder.DropColumn(
            //    name: "SegundaDosisHora",
            //    table: "VacunacionCOVID19");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AddColumn<string>(
            //    name: "PrimeraDosisHora",
            //    table: "VacunacionCOVID19",
            //    maxLength: 10,
            //    nullable: true);

            //migrationBuilder.AddColumn<string>(
            //    name: "SegundaDosisHora",
            //    table: "VacunacionCOVID19",
            //    maxLength: 10,
            //    nullable: true);
        }
    }
}
