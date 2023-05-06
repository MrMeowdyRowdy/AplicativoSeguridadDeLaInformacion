using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AplicativoSeguridad.Data.Migrations
{
    public partial class BDD1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Activo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Identificador = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ubicacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Proceso = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NombreActivo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Responsable = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Clasificacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValEconomico = table.Column<int>(type: "int", nullable: false),
                    ValOps = table.Column<int>(type: "int", nullable: false),
                    ValLegal = table.Column<int>(type: "int", nullable: false),
                    ValRep = table.Column<int>(type: "int", nullable: false),
                    ValPriv = table.Column<int>(type: "int", nullable: false),
                    ValSeg = table.Column<int>(type: "int", nullable: false),
                    Criticidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activo", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Activo");
        }
    }
}
