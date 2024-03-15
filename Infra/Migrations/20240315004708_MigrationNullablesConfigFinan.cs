using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class MigrationNullablesConfigFinan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConfiguracaoFinanceira_Banco_IdBanco",
                table: "ConfiguracaoFinanceira");

            migrationBuilder.DropForeignKey(
                name: "FK_ConfiguracaoFinanceira_CentroCusto_IdCentroCusto",
                table: "ConfiguracaoFinanceira");

            migrationBuilder.DropForeignKey(
                name: "FK_ConfiguracaoFinanceira_Clinica_IdClinica",
                table: "ConfiguracaoFinanceira");

            migrationBuilder.DropForeignKey(
                name: "FK_ConfiguracaoFinanceira_ContaBancaria_IdContaBancaria",
                table: "ConfiguracaoFinanceira");

            migrationBuilder.DropForeignKey(
                name: "FK_ConfiguracaoFinanceira_FormaPagamento_IdFormaPagamento",
                table: "ConfiguracaoFinanceira");

            migrationBuilder.AlterColumn<int>(
                name: "IdFormaPagamento",
                table: "ConfiguracaoFinanceira",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "IdContaBancaria",
                table: "ConfiguracaoFinanceira",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "IdClinica",
                table: "ConfiguracaoFinanceira",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "IdCentroCusto",
                table: "ConfiguracaoFinanceira",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "IdBanco",
                table: "ConfiguracaoFinanceira",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ConfiguracaoFinanceira_Banco_IdBanco",
                table: "ConfiguracaoFinanceira",
                column: "IdBanco",
                principalTable: "Banco",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ConfiguracaoFinanceira_CentroCusto_IdCentroCusto",
                table: "ConfiguracaoFinanceira",
                column: "IdCentroCusto",
                principalTable: "CentroCusto",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ConfiguracaoFinanceira_Clinica_IdClinica",
                table: "ConfiguracaoFinanceira",
                column: "IdClinica",
                principalTable: "Clinica",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ConfiguracaoFinanceira_ContaBancaria_IdContaBancaria",
                table: "ConfiguracaoFinanceira",
                column: "IdContaBancaria",
                principalTable: "ContaBancaria",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ConfiguracaoFinanceira_FormaPagamento_IdFormaPagamento",
                table: "ConfiguracaoFinanceira",
                column: "IdFormaPagamento",
                principalTable: "FormaPagamento",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConfiguracaoFinanceira_Banco_IdBanco",
                table: "ConfiguracaoFinanceira");

            migrationBuilder.DropForeignKey(
                name: "FK_ConfiguracaoFinanceira_CentroCusto_IdCentroCusto",
                table: "ConfiguracaoFinanceira");

            migrationBuilder.DropForeignKey(
                name: "FK_ConfiguracaoFinanceira_Clinica_IdClinica",
                table: "ConfiguracaoFinanceira");

            migrationBuilder.DropForeignKey(
                name: "FK_ConfiguracaoFinanceira_ContaBancaria_IdContaBancaria",
                table: "ConfiguracaoFinanceira");

            migrationBuilder.DropForeignKey(
                name: "FK_ConfiguracaoFinanceira_FormaPagamento_IdFormaPagamento",
                table: "ConfiguracaoFinanceira");

            migrationBuilder.AlterColumn<int>(
                name: "IdFormaPagamento",
                table: "ConfiguracaoFinanceira",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IdContaBancaria",
                table: "ConfiguracaoFinanceira",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IdClinica",
                table: "ConfiguracaoFinanceira",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IdCentroCusto",
                table: "ConfiguracaoFinanceira",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IdBanco",
                table: "ConfiguracaoFinanceira",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ConfiguracaoFinanceira_Banco_IdBanco",
                table: "ConfiguracaoFinanceira",
                column: "IdBanco",
                principalTable: "Banco",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ConfiguracaoFinanceira_CentroCusto_IdCentroCusto",
                table: "ConfiguracaoFinanceira",
                column: "IdCentroCusto",
                principalTable: "CentroCusto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ConfiguracaoFinanceira_Clinica_IdClinica",
                table: "ConfiguracaoFinanceira",
                column: "IdClinica",
                principalTable: "Clinica",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ConfiguracaoFinanceira_ContaBancaria_IdContaBancaria",
                table: "ConfiguracaoFinanceira",
                column: "IdContaBancaria",
                principalTable: "ContaBancaria",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ConfiguracaoFinanceira_FormaPagamento_IdFormaPagamento",
                table: "ConfiguracaoFinanceira",
                column: "IdFormaPagamento",
                principalTable: "FormaPagamento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
