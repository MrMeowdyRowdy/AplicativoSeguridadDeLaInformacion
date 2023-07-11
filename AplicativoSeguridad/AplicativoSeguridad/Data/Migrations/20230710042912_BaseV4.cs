using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AplicativoSeguridad.Data.Migrations
{
    public partial class BaseV4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Seleccion",
                table: "Amenaza");

            migrationBuilder.AddColumn<bool>(
                name: "Hardware",
                table: "Amenaza",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Redes",
                table: "Amenaza",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Software",
                table: "Amenaza",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "TH",
                table: "Amenaza",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Hardware",
                table: "Amenaza");

            migrationBuilder.DropColumn(
                name: "Redes",
                table: "Amenaza");

            migrationBuilder.DropColumn(
                name: "Software",
                table: "Amenaza");

            migrationBuilder.DropColumn(
                name: "TH",
                table: "Amenaza");

            migrationBuilder.AddColumn<string>(
                name: "Seleccion",
                table: "Amenaza",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
