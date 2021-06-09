using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ino_InvisionCore.Infraestructura.Migrations
{
    public partial class PINFechaEmpleadoNULL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AlterColumn<DateTime>(
            //    name: "FechaPIN",
            //    table: "Empleado",
            //    nullable: true,
            //    oldClrType: typeof(DateTime));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AlterColumn<DateTime>(
            //    name: "FechaPIN",
            //    table: "Empleado",
            //    nullable: false,
            //    oldClrType: typeof(DateTime),
            //    oldNullable: true);
        }
    }
}
