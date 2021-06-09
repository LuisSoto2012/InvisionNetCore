using Microsoft.EntityFrameworkCore.Migrations;

namespace Ino_InvisionCore.Infraestructura.Migrations
{
    public partial class SolicitudReprogramacion_AddCorreo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AddColumn<string>(
            //    name: "Correo",
            //    table: "SolicitudReprogramacion",
            //    maxLength: 100,
            //    nullable: false,
            //    defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "Correo",
            //    table: "SolicitudReprogramacion");
        }
    }
}
