using Microsoft.EntityFrameworkCore.Migrations;

namespace Ino_InvisionCore.Infraestructura.Migrations
{
    public partial class Medicamento_QuitarUnidadMedida : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "UnidadMedida",
            //    table: "Medicamento");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AddColumn<string>(
            //    name: "UnidadMedida",
            //    table: "Medicamento",
            //    maxLength: 30,
            //    nullable: false,
            //    defaultValue: "");
        }
    }
}
