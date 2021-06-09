using Microsoft.EntityFrameworkCore.Migrations;

namespace Ino_InvisionCore.Infraestructura.Migrations
{
    public partial class AddMedicoConsultaRapidaEMG : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AddColumn<int>(
            //    name: "IdMedico",
            //    table: "SolicitudConsultaRapida",
            //    nullable: true);

            //migrationBuilder.AddColumn<string>(
            //    name: "Medico",
            //    table: "SolicitudConsultaRapida",
            //    nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "IdMedico",
            //    table: "SolicitudConsultaRapida");

            //migrationBuilder.DropColumn(
            //    name: "Medico",
            //    table: "SolicitudConsultaRapida");
        }
    }
}
