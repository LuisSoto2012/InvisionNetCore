using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ino_InvisionCore.Infraestructura.Migrations
{
    public partial class SolicitudReprogramacion_AddNuevaFechaReprogramacion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AddColumn<DateTime>(
            //    name: "NuevaFechaReprogramacion",
            //    table: "SolicitudReprogramacion",
            //    nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "NuevaFechaReprogramacion",
            //    table: "SolicitudReprogramacion");
        }
    }
}
