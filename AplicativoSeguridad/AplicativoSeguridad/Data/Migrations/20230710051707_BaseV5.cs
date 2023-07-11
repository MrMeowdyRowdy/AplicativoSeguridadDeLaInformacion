using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AplicativoSeguridad.Data.Migrations
{
    public partial class BaseV5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vulnerabilidad",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amenaza = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Activo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NombreActivo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NivAmenaza = table.Column<int>(type: "int", nullable: false),
                    NivVulnerabilidad = table.Column<int>(type: "int", nullable: false),
                    Control = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RiesgoResidual = table.Column<int>(type: "int", nullable: false),
                    NivRiesgo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vulnerabilidad", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vulnerabilidad");
        }
    }
}
