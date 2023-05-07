using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AplicativoSeguridad.Data.Migrations
{
    public partial class UpdateTipe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Tipo",
                table: "Activo",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tipo",
                table: "Activo");
        }
    }
}
