using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ino_InvisionCore.Infraestructura.Migrations
{
    public partial class AddTable_CitaCallCenter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "CitaCallCenter",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        NroDocumento = table.Column<string>(nullable: true),
            //        Paciente = table.Column<string>(nullable: true),
            //        Edad = table.Column<string>(nullable: true),
            //        Sexo = table.Column<string>(nullable: true),
            //        FechaLlamada = table.Column<DateTime>(nullable: false),
            //        InicioLlamada = table.Column<string>(nullable: true),
            //        FinLlamada = table.Column<string>(nullable: true),
            //        EsCita = table.Column<bool>(nullable: false),
            //        Especialidad = table.Column<string>(nullable: true),
            //        FechaCita = table.Column<DateTime>(nullable: false),
            //        Telefono = table.Column<string>(nullable: true),
            //        Correo = table.Column<string>(nullable: true),
            //        Motivo = table.Column<string>(nullable: true),
            //        TipoSeguro = table.Column<string>(nullable: true),
            //        EstadoHojaReferencia = table.Column<string>(nullable: true),
            //        Turno = table.Column<string>(nullable: true),
            //        IdUsuarioRegistro = table.Column<int>(nullable: false),
            //        IdUsuarioModificacion = table.Column<int>(nullable: true),
            //        FechaRegistro = table.Column<DateTime>(nullable: false),
            //        FechaModificacion = table.Column<DateTime>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_CitaCallCenter", x => x.Id);
            //    });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "CitaCallCenter");
        }
    }
}
