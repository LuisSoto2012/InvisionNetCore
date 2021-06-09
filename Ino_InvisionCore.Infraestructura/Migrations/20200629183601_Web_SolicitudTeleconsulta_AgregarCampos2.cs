using Microsoft.EntityFrameworkCore.Migrations;

namespace Ino_InvisionCore.Infraestructura.Migrations
{
    public partial class Web_SolicitudTeleconsulta_AgregarCampos2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AddColumn<string>(
            //    name: "FteFto",
            //    table: "SolicitudTeleconsulta",
            //    nullable: true);

            //migrationBuilder.AddColumn<string>(
            //    name: "NroDocumento",
            //    table: "SolicitudTeleconsulta",
            //    maxLength: 20,
            //    nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "FteFto",
            //    table: "SolicitudTeleconsulta");

            //migrationBuilder.DropColumn(
            //    name: "NroDocumento",
            //    table: "SolicitudTeleconsulta");
        }
    }
}
