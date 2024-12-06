using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class MigrationFormaPagamentoTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdClinica",
                table: "FormaPagamento",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_FormaPagamento_IdClinica",
                table: "FormaPagamento",
                column: "IdClinica");

            migrationBuilder.AddForeignKey(
                name: "FK_FormaPagamento_Clinica_IdClinica",
                table: "FormaPagamento",
                column: "IdClinica",
                principalTable: "Clinica",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FormaPagamento_Clinica_IdClinica",
                table: "FormaPagamento");

            migrationBuilder.DropIndex(
                name: "IX_FormaPagamento_IdClinica",
                table: "FormaPagamento");

            migrationBuilder.DropColumn(
                name: "IdClinica",
                table: "FormaPagamento");
        }
    }
}
