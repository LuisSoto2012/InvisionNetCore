using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ino_InvisionCore.Infraestructura.Migrations
{
    public partial class AlterTable_CitaCallCenter_NullableColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AlterColumn<DateTime>(
            //    name: "FechaCita",
            //    table: "CitaCallCenter",
            //    nullable: true,
            //    oldClrType: typeof(DateTime));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AlterColumn<DateTime>(
            //    name: "FechaCita",
            //    table: "CitaCallCenter",
            //    nullable: false,
            //    oldClrType: typeof(DateTime),
            //    oldNullable: true);
        }
    }
}
