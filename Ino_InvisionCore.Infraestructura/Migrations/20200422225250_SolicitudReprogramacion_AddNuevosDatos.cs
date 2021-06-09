using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ino_InvisionCore.Infraestructura.Migrations
{
    public partial class SolicitudReprogramacion_AddNuevosDatos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AddColumn<DateTime>(
            //    name: "FechaReprogramacion",
            //    table: "SolicitudReprogramacion",
            //    nullable: true);

            //migrationBuilder.AddColumn<DateTime>(
            //    name: "FechaValidacion",
            //    table: "SolicitudReprogramacion",
            //    nullable: true);

            //migrationBuilder.AddColumn<int>(
            //    name: "IdUsuarioValida",
            //    table: "SolicitudReprogramacion",
            //    nullable: false,
            //    defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "FechaReprogramacion",
            //    table: "SolicitudReprogramacion");

            //migrationBuilder.DropColumn(
            //    name: "FechaValidacion",
            //    table: "SolicitudReprogramacion");

            //migrationBuilder.DropColumn(
            //    name: "IdUsuarioValida",
            //    table: "SolicitudReprogramacion");
        }
    }
}
