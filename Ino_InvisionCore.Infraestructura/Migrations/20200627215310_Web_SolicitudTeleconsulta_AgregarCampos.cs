using Microsoft.EntityFrameworkCore.Migrations;

namespace Ino_InvisionCore.Infraestructura.Migrations
{
    public partial class Web_SolicitudTeleconsulta_AgregarCampos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AddColumn<int>(
            //    name: "IdMedico",
            //    table: "SolicitudTeleconsulta",
            //    nullable: false,
            //    defaultValue: 0);

            //migrationBuilder.AddColumn<string>(
            //    name: "Medico",
            //    table: "SolicitudTeleconsulta",
            //    nullable: true);

            //migrationBuilder.AddColumn<string>(
            //    name: "NuevoHoraCita",
            //    table: "SolicitudTeleconsulta",
            //    nullable: true);

            //migrationBuilder.AddColumn<string>(
            //    name: "Url",
            //    table: "SolicitudTeleconsulta",
            //    nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "IdMedico",
            //    table: "SolicitudTeleconsulta");

            //migrationBuilder.DropColumn(
            //    name: "Medico",
            //    table: "SolicitudTeleconsulta");

            //migrationBuilder.DropColumn(
            //    name: "NuevoHoraCita",
            //    table: "SolicitudTeleconsulta");

            //migrationBuilder.DropColumn(
            //    name: "Url",
            //    table: "SolicitudTeleconsulta");
        }
    }
}
