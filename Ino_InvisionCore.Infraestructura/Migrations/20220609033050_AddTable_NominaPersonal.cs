using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ino_InvisionCore.Infraestructura.Migrations
{
    public partial class AddTable_NominaPersonal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropPrimaryKey(
            //    name: "PK_AtencionCE",
            //    table: "AtencionCE");

            //migrationBuilder.RenameTable(
            //    name: "AtencionCE",
            //    newName: "AtencionCENew");

            //migrationBuilder.AddPrimaryKey(
            //    name: "PK_AtencionCENew",
            //    table: "AtencionCENew",
            //    column: "IdAtencionCE");

            //migrationBuilder.CreateTable(
            //    name: "Personal",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        NombreCompleto = table.Column<string>(nullable: true),
            //        NumeroDocumento = table.Column<string>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Personal", x => x.Id);
            //    });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "Personal");

            //migrationBuilder.DropPrimaryKey(
            //    name: "PK_AtencionCENew",
            //    table: "AtencionCENew");

            //migrationBuilder.RenameTable(
            //    name: "AtencionCENew",
            //    newName: "AtencionCE");

            //migrationBuilder.AddPrimaryKey(
            //    name: "PK_AtencionCE",
            //    table: "AtencionCE",
            //    column: "IdAtencionCE");
        }
    }
}
