using Microsoft.EntityFrameworkCore.Migrations;

namespace Ino_InvisionCore.Infraestructura.Migrations
{
    public partial class RecetaMEdicaEstandar_OjoFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            //migrationBuilder.AlterColumn<string>(
            //    name: "Ojo",
            //    table: "Medicamento",
            //    maxLength: 50,
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldMaxLength: 2,
            //    oldNullable: true);

            //migrationBuilder.CreateIndex(
            //    name: "IX_OrdenesMedicas_IdTipoOrdenMedica",
            //    table: "OrdenesMedicas",
            //    column: "IdTipoOrdenMedica");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropIndex(
            //    name: "IX_OrdenesMedicas_IdTipoOrdenMedica",
            //    table: "OrdenesMedicas");

            //migrationBuilder.AlterColumn<string>(
            //    name: "Ojo",
            //    table: "Medicamento",
            //    maxLength: 2,
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldMaxLength: 50,
            //    oldNullable: true);

            //migrationBuilder.CreateIndex(
            //    name: "IX_OrdenesMedicas_IdTipoOrdenMedica",
            //    table: "OrdenesMedicas",
            //    column: "IdTipoOrdenMedica",
            //    unique: true);
        }
    }
}
