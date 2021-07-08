using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ino_InvisionCore.Infraestructura.Migrations
{
    public partial class EvaluacionPreAnestesica_QuitarCampos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "Anestesiologo",
            //    table: "EvaluacionPreAnestesica");

            //migrationBuilder.DropColumn(
            //    name: "FechaRegistro",
            //    table: "EvaluacionPreAnestesica");

            //migrationBuilder.DropColumn(
            //    name: "PlanAnestesico_AnestesiaGeneralBalanceada",
            //    table: "EvaluacionPreAnestesica");

            //migrationBuilder.DropColumn(
            //    name: "PlanAnestesico_AnestesiaGeneralInhalatoria",
            //    table: "EvaluacionPreAnestesica");

            //migrationBuilder.RenameColumn(
            //    name: "PlanAnestesico_Sedoanalgesia",
            //    table: "EvaluacionPreAnestesica",
            //    newName: "PlanAnestesico");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.RenameColumn(
            //    name: "PlanAnestesico",
            //    table: "EvaluacionPreAnestesica",
            //    newName: "PlanAnestesico_Sedoanalgesia");

            //migrationBuilder.AddColumn<string>(
            //    name: "Anestesiologo",
            //    table: "EvaluacionPreAnestesica",
            //    nullable: true);

            //migrationBuilder.AddColumn<DateTime>(
            //    name: "FechaRegistro",
            //    table: "EvaluacionPreAnestesica",
            //    nullable: false,
            //    defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            //migrationBuilder.AddColumn<string>(
            //    name: "PlanAnestesico_AnestesiaGeneralBalanceada",
            //    table: "EvaluacionPreAnestesica",
            //    nullable: true);

            //migrationBuilder.AddColumn<string>(
            //    name: "PlanAnestesico_AnestesiaGeneralInhalatoria",
            //    table: "EvaluacionPreAnestesica",
            //    nullable: true);
        }
    }
}
