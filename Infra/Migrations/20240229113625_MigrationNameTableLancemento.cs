using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class MigrationNameTableLancemento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_lancamento_CentroCusto_IdCentroCusto",
                table: "lancamento");

            migrationBuilder.DropForeignKey(
                name: "FK_lancamento_Clinica_IdClinica",
                table: "lancamento");

            migrationBuilder.DropForeignKey(
                name: "FK_lancamento_ContaBancaria_IdContaBancaria",
                table: "lancamento");

            migrationBuilder.DropForeignKey(
                name: "FK_lancamento_Convenio_IdConvenio",
                table: "lancamento");

            migrationBuilder.DropForeignKey(
                name: "FK_lancamento_FormaPagamento_IdFormaPagamento",
                table: "lancamento");

            migrationBuilder.DropForeignKey(
                name: "FK_lancamento_Funcionario_IdFuncionario",
                table: "lancamento");

            migrationBuilder.DropForeignKey(
                name: "FK_lancamento_Paciente_IdPaciente",
                table: "lancamento");

            migrationBuilder.DropForeignKey(
                name: "FK_lancamento_Procedimento_IdProcedimento",
                table: "lancamento");

            migrationBuilder.DropForeignKey(
                name: "FK_lancamento_SubCategoria_IdSubCategoria",
                table: "lancamento");

            migrationBuilder.DropPrimaryKey(
                name: "PK_lancamento",
                table: "lancamento");

            migrationBuilder.RenameTable(
                name: "lancamento",
                newName: "Lancamento");

            migrationBuilder.RenameIndex(
                name: "IX_lancamento_IdSubCategoria",
                table: "Lancamento",
                newName: "IX_Lancamento_IdSubCategoria");

            migrationBuilder.RenameIndex(
                name: "IX_lancamento_IdProcedimento",
                table: "Lancamento",
                newName: "IX_Lancamento_IdProcedimento");

            migrationBuilder.RenameIndex(
                name: "IX_lancamento_IdPaciente",
                table: "Lancamento",
                newName: "IX_Lancamento_IdPaciente");

            migrationBuilder.RenameIndex(
                name: "IX_lancamento_IdFuncionario",
                table: "Lancamento",
                newName: "IX_Lancamento_IdFuncionario");

            migrationBuilder.RenameIndex(
                name: "IX_lancamento_IdFormaPagamento",
                table: "Lancamento",
                newName: "IX_Lancamento_IdFormaPagamento");

            migrationBuilder.RenameIndex(
                name: "IX_lancamento_IdConvenio",
                table: "Lancamento",
                newName: "IX_Lancamento_IdConvenio");

            migrationBuilder.RenameIndex(
                name: "IX_lancamento_IdContaBancaria",
                table: "Lancamento",
                newName: "IX_Lancamento_IdContaBancaria");

            migrationBuilder.RenameIndex(
                name: "IX_lancamento_IdClinica",
                table: "Lancamento",
                newName: "IX_Lancamento_IdClinica");

            migrationBuilder.RenameIndex(
                name: "IX_lancamento_IdCentroCusto",
                table: "Lancamento",
                newName: "IX_Lancamento_IdCentroCusto");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lancamento",
                table: "Lancamento",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Lancamento_CentroCusto_IdCentroCusto",
                table: "Lancamento",
                column: "IdCentroCusto",
                principalTable: "CentroCusto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Lancamento_Clinica_IdClinica",
                table: "Lancamento",
                column: "IdClinica",
                principalTable: "Clinica",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Lancamento_ContaBancaria_IdContaBancaria",
                table: "Lancamento",
                column: "IdContaBancaria",
                principalTable: "ContaBancaria",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Lancamento_Convenio_IdConvenio",
                table: "Lancamento",
                column: "IdConvenio",
                principalTable: "Convenio",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Lancamento_FormaPagamento_IdFormaPagamento",
                table: "Lancamento",
                column: "IdFormaPagamento",
                principalTable: "FormaPagamento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Lancamento_Funcionario_IdFuncionario",
                table: "Lancamento",
                column: "IdFuncionario",
                principalTable: "Funcionario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Lancamento_Paciente_IdPaciente",
                table: "Lancamento",
                column: "IdPaciente",
                principalTable: "Paciente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Lancamento_Procedimento_IdProcedimento",
                table: "Lancamento",
                column: "IdProcedimento",
                principalTable: "Procedimento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Lancamento_SubCategoria_IdSubCategoria",
                table: "Lancamento",
                column: "IdSubCategoria",
                principalTable: "SubCategoria",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lancamento_CentroCusto_IdCentroCusto",
                table: "Lancamento");

            migrationBuilder.DropForeignKey(
                name: "FK_Lancamento_Clinica_IdClinica",
                table: "Lancamento");

            migrationBuilder.DropForeignKey(
                name: "FK_Lancamento_ContaBancaria_IdContaBancaria",
                table: "Lancamento");

            migrationBuilder.DropForeignKey(
                name: "FK_Lancamento_Convenio_IdConvenio",
                table: "Lancamento");

            migrationBuilder.DropForeignKey(
                name: "FK_Lancamento_FormaPagamento_IdFormaPagamento",
                table: "Lancamento");

            migrationBuilder.DropForeignKey(
                name: "FK_Lancamento_Funcionario_IdFuncionario",
                table: "Lancamento");

            migrationBuilder.DropForeignKey(
                name: "FK_Lancamento_Paciente_IdPaciente",
                table: "Lancamento");

            migrationBuilder.DropForeignKey(
                name: "FK_Lancamento_Procedimento_IdProcedimento",
                table: "Lancamento");

            migrationBuilder.DropForeignKey(
                name: "FK_Lancamento_SubCategoria_IdSubCategoria",
                table: "Lancamento");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Lancamento",
                table: "Lancamento");

            migrationBuilder.RenameTable(
                name: "Lancamento",
                newName: "lancamento");

            migrationBuilder.RenameIndex(
                name: "IX_Lancamento_IdSubCategoria",
                table: "lancamento",
                newName: "IX_lancamento_IdSubCategoria");

            migrationBuilder.RenameIndex(
                name: "IX_Lancamento_IdProcedimento",
                table: "lancamento",
                newName: "IX_lancamento_IdProcedimento");

            migrationBuilder.RenameIndex(
                name: "IX_Lancamento_IdPaciente",
                table: "lancamento",
                newName: "IX_lancamento_IdPaciente");

            migrationBuilder.RenameIndex(
                name: "IX_Lancamento_IdFuncionario",
                table: "lancamento",
                newName: "IX_lancamento_IdFuncionario");

            migrationBuilder.RenameIndex(
                name: "IX_Lancamento_IdFormaPagamento",
                table: "lancamento",
                newName: "IX_lancamento_IdFormaPagamento");

            migrationBuilder.RenameIndex(
                name: "IX_Lancamento_IdConvenio",
                table: "lancamento",
                newName: "IX_lancamento_IdConvenio");

            migrationBuilder.RenameIndex(
                name: "IX_Lancamento_IdContaBancaria",
                table: "lancamento",
                newName: "IX_lancamento_IdContaBancaria");

            migrationBuilder.RenameIndex(
                name: "IX_Lancamento_IdClinica",
                table: "lancamento",
                newName: "IX_lancamento_IdClinica");

            migrationBuilder.RenameIndex(
                name: "IX_Lancamento_IdCentroCusto",
                table: "lancamento",
                newName: "IX_lancamento_IdCentroCusto");

            migrationBuilder.AddPrimaryKey(
                name: "PK_lancamento",
                table: "lancamento",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_lancamento_CentroCusto_IdCentroCusto",
                table: "lancamento",
                column: "IdCentroCusto",
                principalTable: "CentroCusto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_lancamento_Clinica_IdClinica",
                table: "lancamento",
                column: "IdClinica",
                principalTable: "Clinica",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_lancamento_ContaBancaria_IdContaBancaria",
                table: "lancamento",
                column: "IdContaBancaria",
                principalTable: "ContaBancaria",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_lancamento_Convenio_IdConvenio",
                table: "lancamento",
                column: "IdConvenio",
                principalTable: "Convenio",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_lancamento_FormaPagamento_IdFormaPagamento",
                table: "lancamento",
                column: "IdFormaPagamento",
                principalTable: "FormaPagamento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_lancamento_Funcionario_IdFuncionario",
                table: "lancamento",
                column: "IdFuncionario",
                principalTable: "Funcionario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_lancamento_Paciente_IdPaciente",
                table: "lancamento",
                column: "IdPaciente",
                principalTable: "Paciente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_lancamento_Procedimento_IdProcedimento",
                table: "lancamento",
                column: "IdProcedimento",
                principalTable: "Procedimento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_lancamento_SubCategoria_IdSubCategoria",
                table: "lancamento",
                column: "IdSubCategoria",
                principalTable: "SubCategoria",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
