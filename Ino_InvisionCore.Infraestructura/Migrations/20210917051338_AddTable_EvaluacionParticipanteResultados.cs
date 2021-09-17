using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ino_InvisionCore.Infraestructura.Migrations
{
    public partial class AddTable_EvaluacionParticipanteResultados : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "EvaluacionParticipante",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Nombres = table.Column<string>(nullable: true),
            //        ApellidoPaterno = table.Column<string>(nullable: true),
            //        ApellidoMaterno = table.Column<string>(nullable: true),
            //        TipoDocumento = table.Column<string>(nullable: true),
            //        NumeroDocumento = table.Column<string>(nullable: true),
            //        FechaEmision = table.Column<DateTime>(nullable: false),
            //        TelefonoMovil = table.Column<string>(nullable: true),
            //        CorreoElectronico = table.Column<string>(nullable: true),
            //        Pais = table.Column<string>(nullable: true),
            //        Ocupacion = table.Column<string>(nullable: true),
            //        Region = table.Column<string>(nullable: true),
            //        Sector = table.Column<string>(nullable: true),
            //        NivelAtencion = table.Column<string>(nullable: true),
            //        IdEstado = table.Column<int>(nullable: false),
            //        FechaCreacion = table.Column<DateTime>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_EvaluacionParticipante", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "EvaluacionResultado",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Modulo = table.Column<string>(nullable: true),
            //        IdParticipante = table.Column<int>(nullable: false),
            //        IdPregunta = table.Column<int>(nullable: false),
            //        Pregunta = table.Column<string>(nullable: true),
            //        IdRespuesta = table.Column<string>(nullable: true),
            //        Respuesta = table.Column<string>(nullable: true),
            //        IdRespuestaCorrecta = table.Column<string>(nullable: true),
            //        RespuestaCorrecta = table.Column<string>(nullable: true),
            //        FechaCreacion = table.Column<DateTime>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_EvaluacionResultado", x => x.Id);
            //    });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "EvaluacionParticipante");

            //migrationBuilder.DropTable(
            //    name: "EvaluacionResultado");
        }
    }
}
