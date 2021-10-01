using Microsoft.EntityFrameworkCore.Migrations;

namespace Ino_InvisionCore.Infraestructura.Migrations
{
    public partial class AlterTable_OrdenesMEdicas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AddColumn<string>(
            //    name: "Cmp",
            //    table: "OrdenesMedicas",
            //    maxLength: 20,
            //    nullable: true);

            //migrationBuilder.AddColumn<string>(
            //    name: "Rne",
            //    table: "OrdenesMedicas",
            //    maxLength: 20,
            //    nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "Cmp",
            //    table: "OrdenesMedicas");

            //migrationBuilder.DropColumn(
            //    name: "Rne",
            //    table: "OrdenesMedicas");
        }
    }
}
