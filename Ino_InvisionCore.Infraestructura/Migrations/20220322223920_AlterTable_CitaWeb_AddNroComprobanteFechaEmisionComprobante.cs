using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ino_InvisionCore.Infraestructura.Migrations
{
    public partial class AlterTable_CitaWeb_AddNroComprobanteFechaEmisionComprobante : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AddColumn<DateTime>(
            //    name: "FechaEmisionComprobante",
            //    table: "CitaWeb",
            //    nullable: true);

            //migrationBuilder.AddColumn<string>(
            //    name: "NroComprobante",
            //    table: "CitaWeb",
            //    nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "FechaEmisionComprobante",
            //    table: "CitaWeb");

            //migrationBuilder.DropColumn(
            //    name: "NroComprobante",
            //    table: "CitaWeb");
        }
    }
}
