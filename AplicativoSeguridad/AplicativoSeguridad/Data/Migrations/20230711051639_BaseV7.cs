using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AplicativoSeguridad.Data.Migrations
{
    public partial class BaseV7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Vulnerabilidad",
                newName: "Tolerancia");

            migrationBuilder.AddColumn<string>(
                name: "Codigo",
                table: "Vulnerabilidad",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Codigo",
                table: "Vulnerabilidad");

            migrationBuilder.RenameColumn(
                name: "Tolerancia",
                table: "Vulnerabilidad",
                newName: "Nombre");
        }
    }
}
