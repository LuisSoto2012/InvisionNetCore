using Microsoft.EntityFrameworkCore.Migrations;

namespace Ino_InvisionCore.Infraestructura.Migrations
{
    public partial class RecetaMedicaEstandar_AgregarNumeroDocumento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AddColumn<string>(
            //    name: "NroDocumento",
            //    table: "RecetaMedicaEstandar",
            //    maxLength: 10,
            //    nullable: false,
            //    defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "NroDocumento",
            //    table: "RecetaMedicaEstandar");
        }
    }
}
