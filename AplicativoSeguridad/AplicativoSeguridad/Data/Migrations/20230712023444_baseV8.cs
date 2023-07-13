using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AplicativoSeguridad.Data.Migrations
{
    public partial class baseV8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Control",
                table: "Vulnerabilidad");

            migrationBuilder.DropColumn(
                name: "NivRiesgo",
                table: "Vulnerabilidad");

            migrationBuilder.DropColumn(
                name: "RiesgoResidual",
                table: "Vulnerabilidad");

            migrationBuilder.RenameColumn(
                name: "Tolerancia",
                table: "Vulnerabilidad",
                newName: "ControlAplicado");

            migrationBuilder.CreateTable(
                name: "RiesgoResidual",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Activo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Vulnerabilidad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Responsable = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tolerancia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NuevoControl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RiesgoRes = table.Column<int>(type: "int", nullable: false),
                    NuevoNivRiesgo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RiesgoResidual", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RiesgoResidual");

            migrationBuilder.RenameColumn(
                name: "ControlAplicado",
                table: "Vulnerabilidad",
                newName: "Tolerancia");

            migrationBuilder.AddColumn<string>(
                name: "Control",
                table: "Vulnerabilidad",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NivRiesgo",
                table: "Vulnerabilidad",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RiesgoResidual",
                table: "Vulnerabilidad",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
