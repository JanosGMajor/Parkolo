using Microsoft.EntityFrameworkCore.Migrations;

namespace Parkolo.Data.Migrations
{
    public partial class Elso : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Keszlet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlvazSzam = table.Column<string>(type: "nvarchar(17)", maxLength: 17, nullable: true),
                    Tipus = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    KulcsSzam = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Pozicio = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Keszlet", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Keszlet");
        }
    }
}
