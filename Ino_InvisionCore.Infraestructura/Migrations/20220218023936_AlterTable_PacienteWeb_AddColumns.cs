using Microsoft.EntityFrameworkCore.Migrations;

namespace Ino_InvisionCore.Infraestructura.Migrations
{
    public partial class AlterTable_PacienteWeb_AddColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AddColumn<int>(
            //    name: "IdDistritoDomicilio",
            //    table: "PacienteCitaWeb",
            //    nullable: false,
            //    defaultValue: 0);

            //migrationBuilder.AddColumn<int>(
            //    name: "IdGradoInstruccion",
            //    table: "PacienteCitaWeb",
            //    nullable: false,
            //    defaultValue: 0);

            //migrationBuilder.AddColumn<int>(
            //    name: "IdTipoOcupacion",
            //    table: "PacienteCitaWeb",
            //    nullable: false,
            //    defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "IdDistritoDomicilio",
            //    table: "PacienteCitaWeb");

            //migrationBuilder.DropColumn(
            //    name: "IdGradoInstruccion",
            //    table: "PacienteCitaWeb");

            //migrationBuilder.DropColumn(
            //    name: "IdTipoOcupacion",
            //    table: "PacienteCitaWeb");
        }
    }
}
