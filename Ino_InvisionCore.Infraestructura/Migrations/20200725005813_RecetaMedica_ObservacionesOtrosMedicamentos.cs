using Microsoft.EntityFrameworkCore.Migrations;

namespace Ino_InvisionCore.Infraestructura.Migrations
{
    public partial class RecetaMedica_ObservacionesOtrosMedicamentos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AddColumn<string>(
            //    name: "Observaciones",
            //    table: "RecetaMedicaEstandar",
            //    maxLength: 500,
            //    nullable: true);

            //migrationBuilder.AddColumn<string>(
            //    name: "OtrosMedicamentos",
            //    table: "RecetaMedicaEstandar",
            //    maxLength: 500,
            //    nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "Observaciones",
            //    table: "RecetaMedicaEstandar");

            //migrationBuilder.DropColumn(
            //    name: "OtrosMedicamentos",
            //    table: "RecetaMedicaEstandar");
        }
    }
}
