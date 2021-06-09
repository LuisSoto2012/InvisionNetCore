using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ino_InvisionCore.Infraestructura.Migrations
{
    public partial class SolicitudCitaWeb_MedicoFechaHoraCita : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AddColumn<DateTime>(
            //    name: "FechaCita",
            //    table: "SolicitudCita",
            //    nullable: true);

            //migrationBuilder.AddColumn<string>(
            //    name: "HoraCita",
            //    table: "SolicitudCita",
            //    nullable: true);

            //migrationBuilder.AddColumn<int>(
            //    name: "IdMedico",
            //    table: "SolicitudCita",
            //    nullable: false,
            //    defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "FechaCita",
            //    table: "SolicitudCita");

            //migrationBuilder.DropColumn(
            //    name: "HoraCita",
            //    table: "SolicitudCita");

            //migrationBuilder.DropColumn(
            //    name: "IdMedico",
            //    table: "SolicitudCita");
        }
    }
}
