using Microsoft.EntityFrameworkCore.Migrations;

namespace Ino_InvisionCore.Infraestructura.Migrations
{
    public partial class AlterTable_SolicitudConsultaRapida_AddImagenReferencia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AddColumn<string>(
            //    name: "ImagenReferencia",
            //    table: "SolicitudConsultaRapida",
            //    nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "ImagenReferencia",
            //    table: "SolicitudConsultaRapida");
        }
    }
}
