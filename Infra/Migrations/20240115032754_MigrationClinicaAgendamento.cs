using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class MigrationClinicaAgendamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdClinica",
                table: "Agendamento",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Agendamento_IdClinica",
                table: "Agendamento",
                column: "IdClinica");

            migrationBuilder.AddForeignKey(
                name: "FK_Agendamento_Clinica_IdClinica",
                table: "Agendamento",
                column: "IdClinica",
                principalTable: "Clinica",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agendamento_Clinica_IdClinica",
                table: "Agendamento");

            migrationBuilder.DropIndex(
                name: "IX_Agendamento_IdClinica",
                table: "Agendamento");

            migrationBuilder.DropColumn(
                name: "IdClinica",
                table: "Agendamento");
        }
    }
}
