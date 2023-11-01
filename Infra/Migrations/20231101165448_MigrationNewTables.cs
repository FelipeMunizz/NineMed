using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class MigrationNewTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agendamento_Paciente_IdPaciente",
                table: "Agendamento");

            migrationBuilder.DropIndex(
                name: "IX_Agendamento_IdPaciente",
                table: "Agendamento");

            migrationBuilder.RenameColumn(
                name: "IdPaciente",
                table: "Agendamento",
                newName: "SituacaoAgendamento");

            migrationBuilder.AddColumn<int>(
                name: "IdPacienteAgendamento",
                table: "Agendamento",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdProfissionalSaudeAgendamento",
                table: "Agendamento",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "PacienteAgendamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPaciente = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PacienteAgendamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PacienteAgendamento_Paciente_IdPaciente",
                        column: x => x.IdPaciente,
                        principalTable: "Paciente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProfissionalSaudeAgendamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUsuarioClinica = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfissionalSaudeAgendamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProfissionalSaudeAgendamento_UsuarioClinica_IdUsuarioClinica",
                        column: x => x.IdUsuarioClinica,
                        principalTable: "UsuarioClinica",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agendamento_IdPacienteAgendamento",
                table: "Agendamento",
                column: "IdPacienteAgendamento");

            migrationBuilder.CreateIndex(
                name: "IX_Agendamento_IdProfissionalSaudeAgendamento",
                table: "Agendamento",
                column: "IdProfissionalSaudeAgendamento");

            migrationBuilder.CreateIndex(
                name: "IX_PacienteAgendamento_IdPaciente",
                table: "PacienteAgendamento",
                column: "IdPaciente");

            migrationBuilder.CreateIndex(
                name: "IX_ProfissionalSaudeAgendamento_IdUsuarioClinica",
                table: "ProfissionalSaudeAgendamento",
                column: "IdUsuarioClinica");

            migrationBuilder.AddForeignKey(
                name: "FK_Agendamento_Paciente_IdPacienteAgendamento",
                table: "Agendamento",
                column: "IdPacienteAgendamento",
                principalTable: "Paciente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Agendamento_ProfissionalSaudeAgendamento_IdProfissionalSaudeAgendamento",
                table: "Agendamento",
                column: "IdProfissionalSaudeAgendamento",
                principalTable: "ProfissionalSaudeAgendamento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agendamento_Paciente_IdPacienteAgendamento",
                table: "Agendamento");

            migrationBuilder.DropForeignKey(
                name: "FK_Agendamento_ProfissionalSaudeAgendamento_IdProfissionalSaudeAgendamento",
                table: "Agendamento");

            migrationBuilder.DropTable(
                name: "PacienteAgendamento");

            migrationBuilder.DropTable(
                name: "ProfissionalSaudeAgendamento");

            migrationBuilder.DropIndex(
                name: "IX_Agendamento_IdPacienteAgendamento",
                table: "Agendamento");

            migrationBuilder.DropIndex(
                name: "IX_Agendamento_IdProfissionalSaudeAgendamento",
                table: "Agendamento");

            migrationBuilder.DropColumn(
                name: "IdPacienteAgendamento",
                table: "Agendamento");

            migrationBuilder.DropColumn(
                name: "IdProfissionalSaudeAgendamento",
                table: "Agendamento");

            migrationBuilder.RenameColumn(
                name: "SituacaoAgendamento",
                table: "Agendamento",
                newName: "IdPaciente");

            migrationBuilder.CreateIndex(
                name: "IX_Agendamento_IdPaciente",
                table: "Agendamento",
                column: "IdPaciente");

            migrationBuilder.AddForeignKey(
                name: "FK_Agendamento_Paciente_IdPaciente",
                table: "Agendamento",
                column: "IdPaciente",
                principalTable: "Paciente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
