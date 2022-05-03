using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ino_InvisionCore.Infraestructura.Migrations
{
    public partial class AlterTable_IngresoPacienteINO_Salida : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.RenameColumn(
            //    name: "Fecha",
            //    table: "IngresoPacienteINO",
            //    newName: "FechaIngreso");

            //migrationBuilder.AddColumn<DateTime>(
            //    name: "FechaSalida",
            //    table: "IngresoPacienteINO",
            //    nullable: true);

            //migrationBuilder.AddColumn<int>(
            //    name: "IdUsuarioModifica",
            //    table: "IngresoPacienteINO",
            //    nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "FechaSalida",
            //    table: "IngresoPacienteINO");

            //migrationBuilder.DropColumn(
            //    name: "IdUsuarioModifica",
            //    table: "IngresoPacienteINO");

            //migrationBuilder.RenameColumn(
            //    name: "FechaIngreso",
            //    table: "IngresoPacienteINO",
            //    newName: "Fecha");
        }
    }
}
