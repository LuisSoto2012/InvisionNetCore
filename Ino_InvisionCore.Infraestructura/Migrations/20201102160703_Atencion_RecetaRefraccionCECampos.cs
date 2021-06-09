using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ino_InvisionCore.Infraestructura.Migrations
{
    public partial class Atencion_RecetaRefraccionCECampos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AddColumn<string>(
            //    name: "DxOD",
            //    table: "RecetaRefraccionCE",
            //    maxLength: 20,
            //    nullable: true);

            //migrationBuilder.AddColumn<string>(
            //    name: "DxOI",
            //    table: "RecetaRefraccionCE",
            //    maxLength: 20,
            //    nullable: true);

            //migrationBuilder.AddColumn<string>(
            //    name: "NroDocumnto",
            //    table: "RecetaRefraccionCE",
            //    maxLength: 20,
            //    nullable: true);

            //migrationBuilder.AddColumn<string>(
            //    name: "Paciente",
            //    table: "RecetaRefraccionCE",
            //    maxLength: 250,
            //    nullable: true);

            //migrationBuilder.CreateTable(
            //    name: "Bifocal",
            //    columns: table => new
            //    {
            //        IdBifocal = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Descripcion = table.Column<string>(unicode: false, maxLength: 100, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Bifocal", x => x.IdBifocal);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Especificaciones",
            //    columns: table => new
            //    {
            //        IdEspecificacion = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Descripcion = table.Column<string>(unicode: false, maxLength: 200, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Especificaciones", x => x.IdEspecificacion);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Material",
            //    columns: table => new
            //    {
            //        IdMaterial = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Descripcion = table.Column<string>(unicode: false, maxLength: 100, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Material", x => x.IdMaterial);
            //    });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "Bifocal");

            //migrationBuilder.DropTable(
            //    name: "Especificaciones");

            //migrationBuilder.DropTable(
            //    name: "Material");

            //migrationBuilder.DropColumn(
            //    name: "DxOD",
            //    table: "RecetaRefraccionCE");

            //migrationBuilder.DropColumn(
            //    name: "DxOI",
            //    table: "RecetaRefraccionCE");

            //migrationBuilder.DropColumn(
            //    name: "NroDocumnto",
            //    table: "RecetaRefraccionCE");

            //migrationBuilder.DropColumn(
            //    name: "Paciente",
            //    table: "RecetaRefraccionCE");
        }
    }
}
