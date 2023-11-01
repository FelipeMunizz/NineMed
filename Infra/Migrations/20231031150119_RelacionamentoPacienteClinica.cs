using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class RelacionamentoPacienteClinica : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdClinica",
                table: "Paciente",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Paciente_IdClinica",
                table: "Paciente",
                column: "IdClinica");

            migrationBuilder.AddForeignKey(
                name: "FK_Paciente_Clinica_IdClinica",
                table: "Paciente",
                column: "IdClinica",
                principalTable: "Clinica",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Paciente_Clinica_IdClinica",
                table: "Paciente");

            migrationBuilder.DropIndex(
                name: "IX_Paciente_IdClinica",
                table: "Paciente");

            migrationBuilder.DropColumn(
                name: "IdClinica",
                table: "Paciente");
        }
    }
}
