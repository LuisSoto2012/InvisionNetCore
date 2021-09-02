using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ino_InvisionCore.Infraestructura.Migrations
{
    public partial class AgergarTabla_CitaWe32 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropIndex(
            //    name: "IX_PacienteCitaWeb_IdRol",
            //    table: "PacienteCitaWeb");

            ////migrationBuilder.AddColumn<DateTime>(
            ////    name: "FechaEliminacionCita",
            ////    table: "CitaWeb",
            ////    nullable: true);

            ////migrationBuilder.AddColumn<DateTime>(
            ////    name: "FechaValidacionVoucher",
            ////    table: "CitaWeb",
            ////    nullable: true);

            ////migrationBuilder.AddColumn<int>(
            ////    name: "IdEstado",
            ////    table: "CitaWeb",
            ////    nullable: false,
            ////    defaultValue: 0);

            ////migrationBuilder.AddColumn<int>(
            ////    name: "IdUsuarioElimina",
            ////    table: "CitaWeb",
            ////    nullable: true);

            ////migrationBuilder.AddColumn<int>(
            ////    name: "IdUsuarioValidaVoucher",
            ////    table: "CitaWeb",
            ////    nullable: true);

            ////migrationBuilder.AddColumn<string>(
            ////    name: "ImagenVoucher",
            ////    table: "CitaWeb",
            ////    nullable: true);

            ////migrationBuilder.AddColumn<string>(
            ////    name: "Voucher",
            ////    table: "CitaWeb",
            ////    nullable: true);

            ////migrationBuilder.AddColumn<bool>(
            ////    name: "VoucherValido",
            ////    table: "CitaWeb",
            ////    nullable: true);

            //migrationBuilder.CreateIndex(
            //    name: "IX_PacienteCitaWeb_IdRol",
            //    table: "PacienteCitaWeb",
            //    column: "IdRol");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropIndex(
            //    name: "IX_PacienteCitaWeb_IdRol",
            //    table: "PacienteCitaWeb");

            //migrationBuilder.DropColumn(
            //    name: "FechaEliminacionCita",
            //    table: "CitaWeb");

            //migrationBuilder.DropColumn(
            //    name: "FechaValidacionVoucher",
            //    table: "CitaWeb");

            //migrationBuilder.DropColumn(
            //    name: "IdEstado",
            //    table: "CitaWeb");

            //migrationBuilder.DropColumn(
            //    name: "IdUsuarioElimina",
            //    table: "CitaWeb");

            //migrationBuilder.DropColumn(
            //    name: "IdUsuarioValidaVoucher",
            //    table: "CitaWeb");

            //migrationBuilder.DropColumn(
            //    name: "ImagenVoucher",
            //    table: "CitaWeb");

            //migrationBuilder.DropColumn(
            //    name: "Voucher",
            //    table: "CitaWeb");

            //migrationBuilder.DropColumn(
            //    name: "VoucherValido",
            //    table: "CitaWeb");

            //migrationBuilder.CreateIndex(
            //    name: "IX_PacienteCitaWeb_IdRol",
            //    table: "PacienteCitaWeb",
            //    column: "IdRol",
            //    unique: true);
        }
    }
}
