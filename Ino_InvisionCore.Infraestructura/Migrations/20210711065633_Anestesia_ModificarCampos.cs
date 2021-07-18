using Microsoft.EntityFrameworkCore.Migrations;

namespace Ino_InvisionCore.Infraestructura.Migrations
{
    public partial class Anestesia_ModificarCampos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AddColumn<int>(
            //    name: "IdMedico",
            //    table: "EvaluacionPreAnestesica",
            //    nullable: false,
            //    defaultValue: 0);

            //migrationBuilder.AddColumn<string>(
            //    name: "Medico",
            //    table: "EvaluacionPreAnestesica",
            //    nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "IdMedico",
            //    table: "EvaluacionPreAnestesica");

            //migrationBuilder.DropColumn(
            //    name: "Medico",
            //    table: "EvaluacionPreAnestesica");
        }
    }
}
