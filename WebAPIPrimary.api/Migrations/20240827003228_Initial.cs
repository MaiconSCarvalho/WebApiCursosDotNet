using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebAPIPrimary.api.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alunos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cursos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AlunosCursos",
                columns: table => new
                {
                    AlunosId = table.Column<int>(type: "INTEGER", nullable: false),
                    CursosId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunosCursos", x => new { x.AlunosId, x.CursosId });
                    table.ForeignKey(
                        name: "FK_AlunosCursos_Alunos_AlunosId",
                        column: x => x.AlunosId,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlunosCursos_Cursos_CursosId",
                        column: x => x.CursosId,
                        principalTable: "Cursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "Maicon" },
                    { 2, "Bruno" },
                    { 3, "Isadora" },
                    { 4, "Mateus" },
                    { 5, "Gleice" }
                });

            migrationBuilder.InsertData(
                table: "Cursos",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "C#" },
                    { 2, "Javascript" },
                    { 3, "CSS" },
                    { 4, "POO" },
                    { 5, "Angular" },
                    { 6, "Java" },
                    { 7, "Swift" },
                    { 8, "Spark" },
                    { 9, "Glue" },
                    { 10, "Git" },
                    { 11, "EC2" },
                    { 12, "Terraform" },
                    { 13, "S3" },
                    { 14, "SQS" },
                    { 15, "API Gateway" },
                    { 16, "Lambda" },
                    { 17, "Python" },
                    { 18, "Metodologia Agil" },
                    { 19, "TDD" },
                    { 20, "Nodejs" }
                });

            migrationBuilder.InsertData(
                table: "AlunosCursos",
                columns: new[] { "AlunosId", "CursosId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 3 },
                    { 2, 1 },
                    { 2, 2 },
                    { 2, 3 },
                    { 3, 1 },
                    { 3, 2 },
                    { 4, 1 },
                    { 5, 1 },
                    { 5, 4 },
                    { 6, 1 },
                    { 7, 1 },
                    { 8, 1 },
                    { 9, 1 },
                    { 10, 1 },
                    { 11, 2 },
                    { 12, 2 },
                    { 13, 3 },
                    { 14, 3 },
                    { 15, 4 },
                    { 16, 4 },
                    { 17, 1 },
                    { 18, 1 },
                    { 19, 1 },
                    { 20, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlunosCursos_CursosId",
                table: "AlunosCursos",
                column: "CursosId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlunosCursos");

            migrationBuilder.DropTable(
                name: "Alunos");

            migrationBuilder.DropTable(
                name: "Cursos");
        }
    }
}
