using Microsoft.EntityFrameworkCore.Migrations;

namespace Ino_InvisionCore.Infraestructura.Migrations
{
    public partial class EvaluacionPreAnestesica_ModificacionCampos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AlterColumn<string>(
            //    name: "ExamenFisico_LaringoscopiaDificil",
            //    table: "EvaluacionPreAnestesica",
            //    nullable: true,
            //    oldClrType: typeof(bool));

            //migrationBuilder.AddColumn<string>(
            //    name: "OjoProcedimiento",
            //    table: "EvaluacionPreAnestesica",
            //    nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "OjoProcedimiento",
            //    table: "EvaluacionPreAnestesica");

            //migrationBuilder.AlterColumn<bool>(
            //    name: "ExamenFisico_LaringoscopiaDificil",
            //    table: "EvaluacionPreAnestesica",
            //    nullable: false,
            //    oldClrType: typeof(string),
            //    oldNullable: true);
        }
    }
}
