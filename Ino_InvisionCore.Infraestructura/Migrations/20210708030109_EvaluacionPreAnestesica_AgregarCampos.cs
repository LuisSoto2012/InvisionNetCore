using Microsoft.EntityFrameworkCore.Migrations;

namespace Ino_InvisionCore.Infraestructura.Migrations
{
    public partial class EvaluacionPreAnestesica_AgregarCampos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AddColumn<bool>(
            //    name: "ClasificacionASA_Emergencia",
            //    table: "EvaluacionPreAnestesica",
            //    nullable: false,
            //    defaultValue: false);

            //migrationBuilder.AddColumn<int>(
            //    name: "IdAtencion",
            //    table: "EvaluacionPreAnestesica",
            //    nullable: false,
            //    defaultValue: 0);

            //migrationBuilder.AddColumn<int>(
            //    name: "IdEstado",
            //    table: "EvaluacionPreAnestesica",
            //    nullable: false,
            //    defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "ClasificacionASA_Emergencia",
            //    table: "EvaluacionPreAnestesica");

            //migrationBuilder.DropColumn(
            //    name: "IdAtencion",
            //    table: "EvaluacionPreAnestesica");

            //migrationBuilder.DropColumn(
            //    name: "IdEstado",
            //    table: "EvaluacionPreAnestesica");
        }
    }
}
