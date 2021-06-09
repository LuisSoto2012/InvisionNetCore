using Microsoft.EntityFrameworkCore.Migrations;

namespace Ino_InvisionCore.Infraestructura.Migrations
{
    public partial class RecetaMedica_Medicamento_ViaAdministracion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AddColumn<string>(
            //    name: "ViaAdministracion",
            //    table: "Medicamento",
            //    maxLength: 100,
            //    nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "ViaAdministracion",
            //    table: "Medicamento");
        }
    }
}
