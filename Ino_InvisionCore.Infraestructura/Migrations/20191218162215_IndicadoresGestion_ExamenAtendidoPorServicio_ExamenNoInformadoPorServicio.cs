using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ino_InvisionCore.Infraestructura.Migrations
{
    public partial class IndicadoresGestion_ExamenAtendidoPorServicio_ExamenNoInformadoPorServicio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AddColumn<string>(
            //    name: "NroDocumento",
            //    table: "Archivo",
            //    nullable: true);

            //migrationBuilder.CreateTable(
            //    name: "ExamenAtendidoPorServicio",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        FechaOcurrencia = table.Column<DateTime>(nullable: false),
            //        IdEspecialidad = table.Column<int>(nullable: false),
            //        Especialidad = table.Column<string>(maxLength: 50, nullable: false),
            //        TotalPacientes = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_ExamenAtendidoPorServicio", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "ExamenNoInformadoPorServicio",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        FechaOcurrencia = table.Column<DateTime>(nullable: false),
            //        IdEspecialidad = table.Column<int>(nullable: false),
            //        Especialidad = table.Column<string>(maxLength: 50, nullable: false),
            //        TotalPacientes = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_ExamenNoInformadoPorServicio", x => x.Id);
            //    });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "ExamenAtendidoPorServicio");

            //migrationBuilder.DropTable(
            //    name: "ExamenNoInformadoPorServicio");

            //migrationBuilder.DropColumn(
            //    name: "NroDocumento",
            //    table: "Archivo");
        }
    }
}
