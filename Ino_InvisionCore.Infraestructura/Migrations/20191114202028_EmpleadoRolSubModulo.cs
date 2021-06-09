using Microsoft.EntityFrameworkCore.Migrations;

namespace Ino_InvisionCore.Infraestructura.Migrations
{
    public partial class EmpleadoRolSubModulo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_RolSubModulo_Rol_IdRol",
            //    table: "RolSubModulo");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_RolSubModulo_SubModulo_IdSubModulo",
            //    table: "RolSubModulo");

            //migrationBuilder.DropPrimaryKey(
            //    name: "PK_RolSubModulo",
            //    table: "RolSubModulo");

            //migrationBuilder.DropIndex(
            //    name: "IX_RolSubModulo_IdRol",
            //    table: "RolSubModulo");

            //migrationBuilder.AddUniqueConstraint(
            //    name: "AK_RolSubModulo_IdRolSubModulo",
            //    table: "RolSubModulo",
            //    column: "IdRolSubModulo");

            //migrationBuilder.AddPrimaryKey(
            //    name: "PK_RolSubModulo",
            //    table: "RolSubModulo",
            //    columns: new[] { "IdRol", "IdSubModulo" });

            //migrationBuilder.AddForeignKey(
            //    name: "FK_RolSubModulo_Rol_IdRol",
            //    table: "RolSubModulo",
            //    column: "IdRol",
            //    principalTable: "Rol",
            //    principalColumn: "IdRol",
            //    onDelete: ReferentialAction.Restrict);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_RolSubModulo_SubModulo_IdSubModulo",
            //    table: "RolSubModulo",
            //    column: "IdSubModulo",
            //    principalTable: "SubModulo",
            //    principalColumn: "IdSubModulo",
            //    onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_RolSubModulo_Rol_IdRol",
            //    table: "RolSubModulo");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_RolSubModulo_SubModulo_IdSubModulo",
            //    table: "RolSubModulo");

            //migrationBuilder.DropUniqueConstraint(
            //    name: "AK_RolSubModulo_IdRolSubModulo",
            //    table: "RolSubModulo");

            //migrationBuilder.DropPrimaryKey(
            //    name: "PK_RolSubModulo",
            //    table: "RolSubModulo");

            //migrationBuilder.AddPrimaryKey(
            //    name: "PK_RolSubModulo",
            //    table: "RolSubModulo",
            //    column: "IdRolSubModulo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_RolSubModulo_IdRol",
            //    table: "RolSubModulo",
            //    column: "IdRol");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_RolSubModulo_Rol_IdRol",
            //    table: "RolSubModulo",
            //    column: "IdRol",
            //    principalTable: "Rol",
            //    principalColumn: "IdRol",
            //    onDelete: ReferentialAction.Cascade);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_RolSubModulo_SubModulo_IdSubModulo",
            //    table: "RolSubModulo",
            //    column: "IdSubModulo",
            //    principalTable: "SubModulo",
            //    principalColumn: "IdSubModulo",
            //    onDelete: ReferentialAction.Cascade);
        }
    }
}
