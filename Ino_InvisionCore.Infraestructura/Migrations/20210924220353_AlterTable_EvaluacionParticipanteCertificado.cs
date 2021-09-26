using Microsoft.EntityFrameworkCore.Migrations;

namespace Ino_InvisionCore.Infraestructura.Migrations
{
    public partial class AlterTable_EvaluacionParticipanteCertificado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AddColumn<string>(
            //    name: "CorreoElectronico",
            //    table: "EvaluacionParticipanteCertificado",
            //    nullable: true);

            //migrationBuilder.AddColumn<string>(
            //    name: "NumeroDocumento",
            //    table: "EvaluacionParticipanteCertificado",
            //    nullable: true);

            //migrationBuilder.AddColumn<string>(
            //    name: "Participante",
            //    table: "EvaluacionParticipanteCertificado",
            //    nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "CorreoElectronico",
            //    table: "EvaluacionParticipanteCertificado");

            //migrationBuilder.DropColumn(
            //    name: "NumeroDocumento",
            //    table: "EvaluacionParticipanteCertificado");

            //migrationBuilder.DropColumn(
            //    name: "Participante",
            //    table: "EvaluacionParticipanteCertificado");
        }
    }
}
