using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AplicativoSeguridad.Data.Migrations
{
    public partial class baseV9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RiesgoInherente",
                table: "Vulnerabilidad",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ValorRiesgo",
                table: "Vulnerabilidad",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RiesgoInherente",
                table: "Vulnerabilidad");

            migrationBuilder.DropColumn(
                name: "ValorRiesgo",
                table: "Vulnerabilidad");
        }
    }
}
