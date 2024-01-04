using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class NewPacienteModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Paciente_PacienteConvenio_IdPacienteConvenio",
                table: "Paciente");

            migrationBuilder.DropForeignKey(
                name: "FK_Paciente_PacienteFamiliar_IdPacienteFamiliar",
                table: "Paciente");

            migrationBuilder.DropIndex(
                name: "IX_Paciente_IdPacienteConvenio",
                table: "Paciente");

            migrationBuilder.DropIndex(
                name: "IX_Paciente_IdPacienteFamiliar",
                table: "Paciente");

            migrationBuilder.DropColumn(
                name: "IdPacienteConvenio",
                table: "Paciente");

            migrationBuilder.DropColumn(
                name: "IdPacienteFamiliar",
                table: "Paciente");

            migrationBuilder.AddColumn<int>(
                name: "IdPaciente",
                table: "PacienteFamiliar",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdPaciente",
                table: "PacienteConvenio",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PacienteFamiliar_IdPaciente",
                table: "PacienteFamiliar",
                column: "IdPaciente");

            migrationBuilder.CreateIndex(
                name: "IX_PacienteConvenio_IdPaciente",
                table: "PacienteConvenio",
                column: "IdPaciente");

            migrationBuilder.AddForeignKey(
                name: "FK_PacienteConvenio_Paciente_IdPaciente",
                table: "PacienteConvenio",
                column: "IdPaciente",
                principalTable: "Paciente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PacienteFamiliar_Paciente_IdPaciente",
                table: "PacienteFamiliar",
                column: "IdPaciente",
                principalTable: "Paciente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PacienteConvenio_Paciente_IdPaciente",
                table: "PacienteConvenio");

            migrationBuilder.DropForeignKey(
                name: "FK_PacienteFamiliar_Paciente_IdPaciente",
                table: "PacienteFamiliar");

            migrationBuilder.DropIndex(
                name: "IX_PacienteFamiliar_IdPaciente",
                table: "PacienteFamiliar");

            migrationBuilder.DropIndex(
                name: "IX_PacienteConvenio_IdPaciente",
                table: "PacienteConvenio");

            migrationBuilder.DropColumn(
                name: "IdPaciente",
                table: "PacienteFamiliar");

            migrationBuilder.DropColumn(
                name: "IdPaciente",
                table: "PacienteConvenio");

            migrationBuilder.AddColumn<int>(
                name: "IdPacienteConvenio",
                table: "Paciente",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdPacienteFamiliar",
                table: "Paciente",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Paciente_IdPacienteConvenio",
                table: "Paciente",
                column: "IdPacienteConvenio");

            migrationBuilder.CreateIndex(
                name: "IX_Paciente_IdPacienteFamiliar",
                table: "Paciente",
                column: "IdPacienteFamiliar");

            migrationBuilder.AddForeignKey(
                name: "FK_Paciente_PacienteConvenio_IdPacienteConvenio",
                table: "Paciente",
                column: "IdPacienteConvenio",
                principalTable: "PacienteConvenio",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Paciente_PacienteFamiliar_IdPacienteFamiliar",
                table: "Paciente",
                column: "IdPacienteFamiliar",
                principalTable: "PacienteFamiliar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
