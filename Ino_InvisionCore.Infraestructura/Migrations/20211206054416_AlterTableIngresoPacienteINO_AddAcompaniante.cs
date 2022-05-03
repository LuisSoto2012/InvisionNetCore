using Microsoft.EntityFrameworkCore.Migrations;

namespace Ino_InvisionCore.Infraestructura.Migrations
{
    public partial class AlterTableIngresoPacienteINO_AddAcompaniante : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AddColumn<string>(
            //    name: "Acompaniante",
            //    table: "IngresoPacienteINO",
            //    nullable: true);

            //migrationBuilder.AddColumn<string>(
            //    name: "DocumentoPaciente",
            //    table: "IngresoPacienteINO",
            //    nullable: true);

            //migrationBuilder.AddColumn<bool>(
            //    name: "EsAcompaniante",
            //    table: "IngresoPacienteINO",
            //    nullable: false,
            //    defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "Acompaniante",
            //    table: "IngresoPacienteINO");

            //migrationBuilder.DropColumn(
            //    name: "DocumentoPaciente",
            //    table: "IngresoPacienteINO");

            //migrationBuilder.DropColumn(
            //    name: "EsAcompaniante",
            //    table: "IngresoPacienteINO");
        }
    }
}
