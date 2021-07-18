using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ino_InvisionCore.Infraestructura.Migrations
{
    public partial class CitasWeb_AgregarTabla : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "PacienteCitaWeb",
            //    columns: table => new
            //    {
            //        IdUsuarioCreacion = table.Column<int>(nullable: false),
            //        IdUsuarioModificacion = table.Column<int>(nullable: true),
            //        FechaCreacion = table.Column<DateTime>(nullable: false),
            //        FechaModificacion = table.Column<DateTime>(nullable: true),
            //        EsActivo = table.Column<bool>(nullable: false),
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        IdPacienteGalenos = table.Column<int>(nullable: false),
            //        ApellidoPaterno = table.Column<string>(maxLength: 200, nullable: false),
            //        ApellidoMaterno = table.Column<string>(maxLength: 200, nullable: false),
            //        Nombres = table.Column<string>(maxLength: 200, nullable: false),
            //        FechaNacimiento = table.Column<DateTime>(nullable: false),
            //        NumeroDocumento = table.Column<string>(maxLength: 15, nullable: false),
            //        TelefonoMovil = table.Column<string>(maxLength: 20, nullable: false),
            //        Direccion = table.Column<string>(maxLength: 500, nullable: false),
            //        IdSexo = table.Column<int>(nullable: false),
            //        IdEstadoCivil = table.Column<int>(nullable: false),
            //        IdTipoDocumento = table.Column<int>(nullable: false),
            //        CorreoElectronico = table.Column<string>(maxLength: 500, nullable: false),
            //        Usuario = table.Column<string>(maxLength: 50, nullable: false),
            //        Contrasena = table.Column<string>(maxLength: 50, nullable: false),
            //        IdRol = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_PacienteCitaWeb", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_PacienteCitaWeb_Rol_IdRol",
            //            column: x => x.IdRol,
            //            principalTable: "Rol",
            //            principalColumn: "IdRol",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_PacienteCitaWeb_IdRol",
            //    table: "PacienteCitaWeb",
            //    column: "IdRol",
            //    unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "PacienteCitaWeb");
        }
    }
}
