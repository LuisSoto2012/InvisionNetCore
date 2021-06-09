using Microsoft.EntityFrameworkCore.Migrations;

namespace Ino_InvisionCore.Infraestructura.Migrations
{
    public partial class NuevoCampo_RecetaMedica_Medico : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AddColumn<string>(
            //    name: "Medico",
            //    table: "RecetaMedicaEstandar",
            //    maxLength: 100,
            //    nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "Medico",
            //    table: "RecetaMedicaEstandar");
        }
    }
}
