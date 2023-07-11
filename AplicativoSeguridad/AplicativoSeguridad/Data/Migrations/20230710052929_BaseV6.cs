using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AplicativoSeguridad.Data.Migrations
{
    public partial class BaseV6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NombreActivo",
                table: "Vulnerabilidad");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NombreActivo",
                table: "Vulnerabilidad",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
