using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ino_InvisionCore.Infraestructura.Migrations
{
    public partial class Covid19_CI_ActualizarCamposRevocatoria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AddColumn<DateTime>(
            //    name: "FechaRegistroRevocatoria",
            //    table: "ConsentimientoInformadoCOVID19",
            //    nullable: true);

            //migrationBuilder.AddColumn<int>(
            //    name: "IdUsuarioRegistroRevocatoria",
            //    table: "ConsentimientoInformadoCOVID19",
            //    nullable: true);

            //migrationBuilder.AddColumn<bool>(
            //    name: "RevCI_P1",
            //    table: "ConsentimientoInformadoCOVID19",
            //    nullable: true);

            //migrationBuilder.AddColumn<bool>(
            //    name: "RevCI_P2",
            //    table: "ConsentimientoInformadoCOVID19",
            //    nullable: true);

            //migrationBuilder.AddColumn<bool>(
            //    name: "RevCI_P3",
            //    table: "ConsentimientoInformadoCOVID19",
            //    nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "FechaRegistroRevocatoria",
            //    table: "ConsentimientoInformadoCOVID19");

            //migrationBuilder.DropColumn(
            //    name: "IdUsuarioRegistroRevocatoria",
            //    table: "ConsentimientoInformadoCOVID19");

            //migrationBuilder.DropColumn(
            //    name: "RevCI_P1",
            //    table: "ConsentimientoInformadoCOVID19");

            //migrationBuilder.DropColumn(
            //    name: "RevCI_P2",
            //    table: "ConsentimientoInformadoCOVID19");

            //migrationBuilder.DropColumn(
            //    name: "RevCI_P3",
            //    table: "ConsentimientoInformadoCOVID19");
        }
    }
}
