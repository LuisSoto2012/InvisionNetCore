using Microsoft.EntityFrameworkCore.Migrations;

namespace Ino_InvisionCore.Infraestructura.Migrations
{
    public partial class AlterTableEvaluacionExamenAddColumnEditcolumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AlterColumn<int>(
            //    name: "IdUsuarioModificacion",
            //    table: "EvaluacionExamen",
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldNullable: true);

            //migrationBuilder.AlterColumn<int>(
            //    name: "IdUsuarioCreacion",
            //    table: "EvaluacionExamen",
            //    nullable: false,
            //    oldClrType: typeof(string),
            //    oldNullable: true);

            //migrationBuilder.AddColumn<int>(
            //    name: "IdEstado",
            //    table: "EvaluacionExamen",
            //    nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "IdEstado",
            //    table: "EvaluacionExamen");

            //migrationBuilder.AlterColumn<string>(
            //    name: "IdUsuarioModificacion",
            //    table: "EvaluacionExamen",
            //    nullable: true,
            //    oldClrType: typeof(int),
            //    oldNullable: true);

            //migrationBuilder.AlterColumn<string>(
            //    name: "IdUsuarioCreacion",
            //    table: "EvaluacionExamen",
            //    nullable: true,
            //    oldClrType: typeof(int));
        }
    }
}
