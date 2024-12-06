using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class MigrationNewTablesConvenio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CodOperadora",
                table: "Convenio",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Executante",
                table: "Convenio",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProximaGuia",
                table: "Convenio",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProximoLote",
                table: "Convenio",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "SADT",
                table: "Convenio",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "VersaoTISS",
                table: "Convenio",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PlanosConvenio",
                columns: table => new
                {
                    IdConvenio = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanosConvenio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlanosConvenio_Convenio_IdConvenio",
                        column: x => x.IdConvenio,
                        principalTable: "Convenio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProfissionaisSaudeConvenio",
                columns: table => new
                {
                    IdConvenio = table.Column<int>(type: "int", nullable: false),
                    IdFuncionario = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfissionaisSaudeConvenio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProfissionaisSaudeConvenio_Convenio_IdConvenio",
                        column: x => x.IdConvenio,
                        principalTable: "Convenio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfissionaisSaudeConvenio_Funcionario_IdFuncionario",
                        column: x => x.IdFuncionario,
                        principalTable: "Funcionario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlanosConvenio_IdConvenio",
                table: "PlanosConvenio",
                column: "IdConvenio");

            migrationBuilder.CreateIndex(
                name: "IX_ProfissionaisSaudeConvenio_IdConvenio",
                table: "ProfissionaisSaudeConvenio",
                column: "IdConvenio");

            migrationBuilder.CreateIndex(
                name: "IX_ProfissionaisSaudeConvenio_IdFuncionario",
                table: "ProfissionaisSaudeConvenio",
                column: "IdFuncionario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlanosConvenio");

            migrationBuilder.DropTable(
                name: "ProfissionaisSaudeConvenio");

            migrationBuilder.DropColumn(
                name: "CodOperadora",
                table: "Convenio");

            migrationBuilder.DropColumn(
                name: "Executante",
                table: "Convenio");

            migrationBuilder.DropColumn(
                name: "ProximaGuia",
                table: "Convenio");

            migrationBuilder.DropColumn(
                name: "ProximoLote",
                table: "Convenio");

            migrationBuilder.DropColumn(
                name: "SADT",
                table: "Convenio");

            migrationBuilder.DropColumn(
                name: "VersaoTISS",
                table: "Convenio");
        }
    }
}
