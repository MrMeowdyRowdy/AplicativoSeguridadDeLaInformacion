using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AplicativoSeguridad.Data.Migrations
{
    public partial class BDD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //               name: "Activo",
            //               columns: table => new
            //               {
            //                   Id = table.Column<string>(nullable: false),
            //                   Identificador = table.Column<string>(maxLength: 6, nullable: false),
            //                   Ubicacion = table.Column<string>(maxLength: 100, nullable: false),
            //                   Proceso = table.Column<string>(maxLength: 100, nullable: false),
            //                   NombreActivo = table.Column<string>(maxLength: 100, nullable: false),
            //                   Descripcion = table.Column<string>(maxLength: 100, nullable: false),
            //                   Responsable = table.Column<string>(maxLength: 100, nullable: false),
            //                   bicacion = table.Column<string>(maxLength: 100, nullable: false),

            //                   Email = table.Column<string>(maxLength: 256, nullable: true),
            //                   NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
            //                   EmailConfirmed = table.Column<bool>(nullable: false),
            //                   PasswordHash = table.Column<string>(nullable: true),
            //                   SecurityStamp = table.Column<string>(nullable: true),
            //                   ConcurrencyStamp = table.Column<string>(nullable: true),
            //                   PhoneNumber = table.Column<string>(nullable: true),
            //                   PhoneNumberConfirmed = table.Column<bool>(nullable: false),
            //                   TwoFactorEnabled = table.Column<bool>(nullable: false),
            //                   LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
            //                   LockoutEnabled = table.Column<bool>(nullable: false),
            //                   AccessFailedCount = table.Column<int>(nullable: false)
            //               },
            //               constraints: table =>
            //               {
            //                   table.PrimaryKey("PK_AspNetUsers", x => x.Id);
            //               });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
