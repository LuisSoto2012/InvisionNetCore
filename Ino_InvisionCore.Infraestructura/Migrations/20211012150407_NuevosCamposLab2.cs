using Microsoft.EntityFrameworkCore.Migrations;

namespace Ino_InvisionCore.Infraestructura.Migrations
{
    public partial class NuevosCamposLab2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Origen",
                table: "VenopunturasFallidas",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Origen",
                table: "TranscripcionErroneaInoportuna",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Origen",
                table: "TranscripcionErronea",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Origen",
                table: "SueroMalReferenciado",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Origen",
                table: "SolicitudDatosIncompletos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Origen",
                table: "RendimientoHoraTrabajador",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Origen",
                table: "RecoleccionMuestra",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Origen",
                table: "PruebasNoRealizadas",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Origen",
                table: "PocoFrecuente",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Origen",
                table: "PacienteSinResultado",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Origen",
                table: "MuestraHemolizadaLipemica",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Origen",
                table: "MaterialNoCalibrado",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Origen",
                table: "IncumplimientoAnalisis",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Origen",
                table: "IncidentesPacientes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Origen",
                table: "EquipoUPS",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Origen",
                table: "EquipoMalCalibrado",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Origen",
                table: "EmpleoReactivo",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Origen",
                table: "CalibracionDeficiente",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Origen",
                table: "VenopunturasFallidas");

            migrationBuilder.DropColumn(
                name: "Origen",
                table: "TranscripcionErroneaInoportuna");

            migrationBuilder.DropColumn(
                name: "Origen",
                table: "TranscripcionErronea");

            migrationBuilder.DropColumn(
                name: "Origen",
                table: "SueroMalReferenciado");

            migrationBuilder.DropColumn(
                name: "Origen",
                table: "SolicitudDatosIncompletos");

            migrationBuilder.DropColumn(
                name: "Origen",
                table: "RendimientoHoraTrabajador");

            migrationBuilder.DropColumn(
                name: "Origen",
                table: "RecoleccionMuestra");

            migrationBuilder.DropColumn(
                name: "Origen",
                table: "PruebasNoRealizadas");

            migrationBuilder.DropColumn(
                name: "Origen",
                table: "PocoFrecuente");

            migrationBuilder.DropColumn(
                name: "Origen",
                table: "PacienteSinResultado");

            migrationBuilder.DropColumn(
                name: "Origen",
                table: "MuestraHemolizadaLipemica");

            migrationBuilder.DropColumn(
                name: "Origen",
                table: "MaterialNoCalibrado");

            migrationBuilder.DropColumn(
                name: "Origen",
                table: "IncumplimientoAnalisis");

            migrationBuilder.DropColumn(
                name: "Origen",
                table: "IncidentesPacientes");

            migrationBuilder.DropColumn(
                name: "Origen",
                table: "EquipoUPS");

            migrationBuilder.DropColumn(
                name: "Origen",
                table: "EquipoMalCalibrado");

            migrationBuilder.DropColumn(
                name: "Origen",
                table: "EmpleoReactivo");

            migrationBuilder.DropColumn(
                name: "Origen",
                table: "CalibracionDeficiente");
        }
    }
}
