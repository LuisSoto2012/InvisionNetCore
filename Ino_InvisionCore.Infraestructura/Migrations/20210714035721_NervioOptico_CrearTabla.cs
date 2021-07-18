using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ino_InvisionCore.Infraestructura.Migrations
{
    public partial class NervioOptico_CrearTabla : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "NervioOptico",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        IdAtencion = table.Column<int>(nullable: false),
            //        IdPaciente = table.Column<int>(nullable: false),
            //        Paciente = table.Column<string>(nullable: true),
            //        HistoriaClinica = table.Column<string>(nullable: true),
            //        Edad = table.Column<string>(nullable: true),
            //        DiagnosticoPreoperatorio = table.Column<string>(nullable: true),
            //        Procedimiento = table.Column<string>(nullable: true),
            //        IdMedico = table.Column<int>(nullable: false),
            //        Medico = table.Column<string>(nullable: true),
            //        Confiabilidad_OD = table.Column<string>(nullable: true),
            //        PromedioTotal_OD = table.Column<string>(nullable: true),
            //        AreaAnillo_OD = table.Column<string>(nullable: true),
            //        FibrasNerviosas_OD = table.Column<string>(nullable: true),
            //        RelacionCopia_OD = table.Column<string>(nullable: true),
            //        Confiabilidad_OI = table.Column<string>(nullable: true),
            //        PromedioTotal_OI = table.Column<string>(nullable: true),
            //        AreaAnillo_OI = table.Column<string>(nullable: true),
            //        FibrasNerviosas_OI = table.Column<string>(nullable: true),
            //        RelacionCopia_OI = table.Column<string>(nullable: true),
            //        IdEstado = table.Column<int>(nullable: false),
            //        IdUsuarioCreacion = table.Column<int>(nullable: false),
            //        FechaCreacion = table.Column<DateTime>(nullable: false),
            //        IdUsuarioModificacion = table.Column<int>(nullable: true),
            //        FechaModificacion = table.Column<DateTime>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_NervioOptico", x => x.Id);
            //    });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "NervioOptico");
        }
    }
}
