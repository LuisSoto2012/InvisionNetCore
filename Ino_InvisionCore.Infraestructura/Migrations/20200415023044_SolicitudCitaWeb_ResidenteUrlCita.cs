using Microsoft.EntityFrameworkCore.Migrations;

namespace Ino_InvisionCore.Infraestructura.Migrations
{
    public partial class SolicitudCitaWeb_ResidenteUrlCita : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AddColumn<int>(
            //    name: "IdResidente",
            //    table: "SolicitudCita",
            //    nullable: false,
            //    defaultValue: 0);

            //migrationBuilder.AddColumn<string>(
            //    name: "UrlCita",
            //    table: "SolicitudCita",
            //    nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "IdResidente",
            //    table: "SolicitudCita");

            //migrationBuilder.DropColumn(
            //    name: "UrlCita",
            //    table: "SolicitudCita");
        }
    }
}
