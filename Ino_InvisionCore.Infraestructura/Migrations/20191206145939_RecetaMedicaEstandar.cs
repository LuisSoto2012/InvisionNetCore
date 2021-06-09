using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ino_InvisionCore.Infraestructura.Migrations
{
    public partial class RecetaMedicaEstandar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "TipoAtencion",
            //    columns: table => new
            //    {
            //        IdUsuarioCreacion = table.Column<int>(nullable: false),
            //        IdUsuarioModificacion = table.Column<int>(nullable: true),
            //        FechaCreacion = table.Column<DateTime>(nullable: false),
            //        FechaModificacion = table.Column<DateTime>(nullable: true),
            //        EsActivo = table.Column<bool>(nullable: false),
            //        IdTipoAtencion = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Nombre = table.Column<string>(maxLength: 30, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_TipoAtencion", x => x.IdTipoAtencion);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "RecetaMedicaEstandar",
            //    columns: table => new
            //    {
            //        IdUsuarioCreacion = table.Column<int>(nullable: false),
            //        IdUsuarioModificacion = table.Column<int>(nullable: true),
            //        FechaCreacion = table.Column<DateTime>(nullable: false),
            //        FechaModificacion = table.Column<DateTime>(nullable: true),
            //        EsActivo = table.Column<bool>(nullable: false),
            //        IdRecetaMedica = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        IdAtencion = table.Column<int>(nullable: false),
            //        IdTipoAtencion = table.Column<int>(nullable: false),
            //        Paciente = table.Column<string>(maxLength: 500, nullable: false),
            //        HistoriaClinica = table.Column<string>(maxLength: 10, nullable: false),
            //        Edad = table.Column<int>(nullable: false),
            //        CodigoCIE10 = table.Column<string>(maxLength: 10, nullable: false),
            //        Diagnostico = table.Column<string>(maxLength: 500, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_RecetaMedicaEstandar", x => x.IdRecetaMedica);
            //        table.ForeignKey(
            //            name: "FK_RecetaMedicaEstandar_TipoAtencion_IdTipoAtencion",
            //            column: x => x.IdTipoAtencion,
            //            principalTable: "TipoAtencion",
            //            principalColumn: "IdTipoAtencion",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Medicamento",
            //    columns: table => new
            //    {
            //        IdMedicamento = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        IdRecetaMedica = table.Column<int>(nullable: false),
            //        Nombre = table.Column<string>(maxLength: 100, nullable: false),
            //        ForFarm = table.Column<string>(maxLength: 50, nullable: false),
            //        UnidadMedida = table.Column<string>(maxLength: 30, nullable: false),
            //        Cantidad = table.Column<int>(nullable: false),
            //        Ojo = table.Column<string>(maxLength: 2, nullable: false),
            //        Indicacion = table.Column<string>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Medicamento", x => x.IdMedicamento);
            //        table.ForeignKey(
            //            name: "FK_Medicamento_RecetaMedicaEstandar_IdRecetaMedica",
            //            column: x => x.IdRecetaMedica,
            //            principalTable: "RecetaMedicaEstandar",
            //            principalColumn: "IdRecetaMedica",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_Medicamento_IdRecetaMedica",
            //    table: "Medicamento",
            //    column: "IdRecetaMedica");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "Medicamento");

            //migrationBuilder.DropTable(
            //    name: "RecetaMedicaEstandar");

            //migrationBuilder.DropTable(
            //    name: "TipoAtencion");
        }
    }
}
