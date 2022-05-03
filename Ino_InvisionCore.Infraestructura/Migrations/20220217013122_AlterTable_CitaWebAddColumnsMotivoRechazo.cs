using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ino_InvisionCore.Infraestructura.Migrations
{
    public partial class AlterTable_CitaWebAddColumnsMotivoRechazo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AddColumn<DateTime>(
            //    name: "FechaRechazoVoucher",
            //    table: "CitaWeb",
            //    nullable: true);

            //migrationBuilder.AddColumn<int>(
            //    name: "IdCuentaAtencion",
            //    table: "CitaWeb",
            //    nullable: false,
            //    defaultValue: 0);

            //migrationBuilder.AddColumn<int>(
            //    name: "IdUsuarioRechazoVoucher",
            //    table: "CitaWeb",
            //    nullable: true);

            //migrationBuilder.AddColumn<string>(
            //    name: "MotivoRechazoVoucher",
            //    table: "CitaWeb",
            //    nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "FechaRechazoVoucher",
            //    table: "CitaWeb");

            //migrationBuilder.DropColumn(
            //    name: "IdCuentaAtencion",
            //    table: "CitaWeb");

            //migrationBuilder.DropColumn(
            //    name: "IdUsuarioRechazoVoucher",
            //    table: "CitaWeb");

            //migrationBuilder.DropColumn(
            //    name: "MotivoRechazoVoucher",
            //    table: "CitaWeb");
        }
    }
}
