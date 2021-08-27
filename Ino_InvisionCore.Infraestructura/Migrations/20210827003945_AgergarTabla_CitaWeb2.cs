using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ino_InvisionCore.Infraestructura.Migrations
{
    public partial class AgergarTabla_CitaWeb2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "CitaWeb",
            //    columns: table => new
            //    {
            //        IdCita = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Fecha = table.Column<DateTime>(nullable: false),
            //        HoraInicio = table.Column<string>(nullable: false),
            //        HoraFin = table.Column<string>(nullable: false),
            //        IdPaciente = table.Column<int>(nullable: false),
            //        Paciente = table.Column<string>(nullable: false),
            //        IdEstadoCita = table.Column<int>(nullable: false),
            //        IdAtencionGalenos = table.Column<int>(nullable: false),
            //        IdMedico = table.Column<int>(nullable: false),
            //        Medico = table.Column<string>(nullable: false),
            //        IdEspecialidad = table.Column<int>(nullable: false),
            //        Especialidad = table.Column<string>(nullable: false),
            //        IdServicio = table.Column<int>(nullable: false),
            //        Servicio = table.Column<string>(nullable: false),
            //        IdProgramacion = table.Column<int>(nullable: false),
            //        IdProducto = table.Column<int>(nullable: true),
            //        FechaSolicitud = table.Column<DateTime>(nullable: false),
            //        HoraSolicitud = table.Column<string>(nullable: true),
            //        EsCitaAdicional = table.Column<bool>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_CitaWeb", x => x.IdCita);
            //    });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "CitaWeb");
        }
    }
}
