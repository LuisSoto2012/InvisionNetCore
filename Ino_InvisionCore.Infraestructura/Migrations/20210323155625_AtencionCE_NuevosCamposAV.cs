using Microsoft.EntityFrameworkCore.Migrations;

namespace Ino_InvisionCore.Infraestructura.Migrations
{
    public partial class AtencionCE_NuevosCamposAV : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AddColumn<string>(
            //    name: "AvConCorreccionOD",
            //    table: "AtencionCE",
            //    nullable: true);

            //migrationBuilder.AddColumn<string>(
            //    name: "AvConCorreccionOI",
            //    table: "AtencionCE",
            //    nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "AvConCorreccionOD",
            //    table: "AtencionCE");

            //migrationBuilder.DropColumn(
            //    name: "AvConCorreccionOI",
            //    table: "AtencionCE");
        }
    }
}
