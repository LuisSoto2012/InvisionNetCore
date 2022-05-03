using Microsoft.EntityFrameworkCore.Migrations;

namespace Ino_InvisionCore.Infraestructura.Migrations
{
    public partial class AlterTable_IngresoPacienteINO_Puerta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AddColumn<string>(
            //    name: "PuertaIngreso",
            //    table: "IngresoPacienteINO",
            //    nullable: true);

            //migrationBuilder.AddColumn<string>(
            //    name: "PuertaSalida",
            //    table: "IngresoPacienteINO",
            //    nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "PuertaIngreso",
            //    table: "IngresoPacienteINO");

            //migrationBuilder.DropColumn(
            //    name: "PuertaSalida",
            //    table: "IngresoPacienteINO");
        }
    }
}
