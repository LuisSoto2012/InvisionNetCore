using Microsoft.EntityFrameworkCore.Migrations;

namespace Ino_InvisionCore.Infraestructura.Migrations
{
    public partial class altertable_solicituconsultarapida_addcolumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AddColumn<string>(
            //    name: "NumeroReferencia",
            //    table: "SolicitudConsultaRapida",
            //    nullable: true);

            //migrationBuilder.AddColumn<int>(
            //    name: "TipoSeguro",
            //    table: "SolicitudConsultaRapida",
            //    nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "NumeroReferencia",
            //    table: "SolicitudConsultaRapida");

            //migrationBuilder.DropColumn(
            //    name: "TipoSeguro",
            //    table: "SolicitudConsultaRapida");
        }
    }
}
