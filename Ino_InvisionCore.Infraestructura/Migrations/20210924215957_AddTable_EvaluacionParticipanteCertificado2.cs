using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ino_InvisionCore.Infraestructura.Migrations
{
    public partial class AddTable_EvaluacionParticipanteCertificado2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "EvaluacionParticipanteCertificado",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        IdParticipante = table.Column<int>(nullable: false),
            //        Modulo = table.Column<string>(nullable: true),
            //        FechaCertificado = table.Column<DateTime>(nullable: false),
            //        FechaEnvio = table.Column<DateTime>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_EvaluacionParticipanteCertificado", x => x.Id);
            //    });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "EvaluacionParticipanteCertificado");
        }
    }
}
