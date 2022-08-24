using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace politecnico.Migrations
{
    public partial class initiald : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Matter",
                table: "turn");

            migrationBuilder.CreateTable(
                name: "Materia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdProfesor = table.Column<int>(type: "int", nullable: false),
                    IdClassroom = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materia", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Materia");

            migrationBuilder.AddColumn<string>(
                name: "Matter",
                table: "turn",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
