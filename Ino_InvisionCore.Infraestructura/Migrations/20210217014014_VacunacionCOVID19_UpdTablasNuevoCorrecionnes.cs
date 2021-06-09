using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ino_InvisionCore.Infraestructura.Migrations
{
    public partial class VacunacionCOVID19_UpdTablasNuevoCorrecionnes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "FechaRegistro",
            //    table: "VacunacionCOVID19");

            //migrationBuilder.RenameColumn(
            //    name: "IdUsuarioRegistro",
            //    table: "VacunacionCOVID19",
            //    newName: "IdUsuarioRegistroPrimeraDosis");

            //migrationBuilder.AddColumn<DateTime>(
            //    name: "FechaRegistroPrimeraPrimeraDosisReaccionesAdversas",
            //    table: "VacunacionCOVID19",
            //    nullable: true);

            //migrationBuilder.AddColumn<DateTime>(
            //    name: "FechaRegistroSegundaDosisReaccionesAdversas",
            //    table: "VacunacionCOVID19",
            //    nullable: true);

            //migrationBuilder.AddColumn<int>(
            //    name: "IdUsuarioRegistroPrimeraDosisReaccionesAdversas",
            //    table: "VacunacionCOVID19",
            //    nullable: true);

            //migrationBuilder.AddColumn<int>(
            //    name: "IdUsuarioRegistroSegundaDosis",
            //    table: "VacunacionCOVID19",
            //    nullable: true);

            //migrationBuilder.AddColumn<int>(
            //    name: "IdUsuarioRegistroSegundaDosisReaccionesAdversas",
            //    table: "VacunacionCOVID19",
            //    nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "FechaRegistroPrimeraPrimeraDosisReaccionesAdversas",
            //    table: "VacunacionCOVID19");

            //migrationBuilder.DropColumn(
            //    name: "FechaRegistroSegundaDosisReaccionesAdversas",
            //    table: "VacunacionCOVID19");

            //migrationBuilder.DropColumn(
            //    name: "IdUsuarioRegistroPrimeraDosisReaccionesAdversas",
            //    table: "VacunacionCOVID19");

            //migrationBuilder.DropColumn(
            //    name: "IdUsuarioRegistroSegundaDosis",
            //    table: "VacunacionCOVID19");

            //migrationBuilder.DropColumn(
            //    name: "IdUsuarioRegistroSegundaDosisReaccionesAdversas",
            //    table: "VacunacionCOVID19");

            //migrationBuilder.RenameColumn(
            //    name: "IdUsuarioRegistroPrimeraDosis",
            //    table: "VacunacionCOVID19",
            //    newName: "IdUsuarioRegistro");

            //migrationBuilder.AddColumn<DateTime>(
            //    name: "FechaRegistro",
            //    table: "VacunacionCOVID19",
            //    nullable: false,
            //    defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
