using Microsoft.EntityFrameworkCore.Migrations;

namespace Ino_InvisionCore.Infraestructura.Migrations
{
    public partial class Web_SolicitudTeleconsulta_QuitarCampos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "ApellidosPaciente",
            //    table: "SolicitudTeleconsulta");

            //migrationBuilder.DropColumn(
            //    name: "NombresPaciente",
            //    table: "SolicitudTeleconsulta");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AddColumn<string>(
            //    name: "ApellidosPaciente",
            //    table: "SolicitudTeleconsulta",
            //    nullable: true);

            //migrationBuilder.AddColumn<string>(
            //    name: "NombresPaciente",
            //    table: "SolicitudTeleconsulta",
            //    nullable: true);
        }
    }
}
