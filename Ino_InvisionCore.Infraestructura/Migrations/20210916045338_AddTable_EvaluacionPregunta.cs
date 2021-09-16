using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ino_InvisionCore.Infraestructura.Migrations
{
    public partial class AddTable_EvaluacionPregunta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "EvaluacionPregunta",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Modulo = table.Column<string>(maxLength: 100, nullable: false),
            //        Pregunta = table.Column<string>(nullable: false),
            //        Respuestas = table.Column<string>(nullable: false),
            //        Activo = table.Column<bool>(nullable: false),
            //        IdUsuarioCreacion = table.Column<int>(nullable: false),
            //        FechaCreacion = table.Column<DateTime>(nullable: false),
            //        IdUsuarioModificacion = table.Column<int>(nullable: true),
            //        FechaModificacion = table.Column<DateTime>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_EvaluacionPregunta", x => x.Id);
            //    });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "EvaluacionPregunta");
        }
    }
}
