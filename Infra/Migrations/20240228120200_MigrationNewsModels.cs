using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class MigrationNewsModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Banco",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodBanco = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdClinica = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banco", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Banco_Clinica_IdClinica",
                        column: x => x.IdClinica,
                        principalTable: "Clinica",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CategoriaFinanceira",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    IdClinica = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriaFinanceira", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CategoriaFinanceira_Clinica_IdClinica",
                        column: x => x.IdClinica,
                        principalTable: "Clinica",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CentroCusto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdClinica = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CentroCusto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CentroCusto_Clinica_IdClinica",
                        column: x => x.IdClinica,
                        principalTable: "Clinica",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContaBancaria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SaldoInicial = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DataSaldo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Agencia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Conta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdBanco = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContaBancaria", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContaBancaria_Banco_IdBanco",
                        column: x => x.IdBanco,
                        principalTable: "Banco",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubCategoria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCategoriaFinanceira = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategoria", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubCategoria_CategoriaFinanceira_IdCategoriaFinanceira",
                        column: x => x.IdCategoriaFinanceira,
                        principalTable: "CategoriaFinanceira",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConfiguracaoFinanceira",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdBanco = table.Column<int>(type: "int", nullable: false),
                    IdContaBancaria = table.Column<int>(type: "int", nullable: false),
                    IdCentroCusto = table.Column<int>(type: "int", nullable: false),
                    IdFormaPagamento = table.Column<int>(type: "int", nullable: false),
                    IdClinica = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfiguracaoFinanceira", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConfiguracaoFinanceira_Banco_IdBanco",
                        column: x => x.IdBanco,
                        principalTable: "Banco",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConfiguracaoFinanceira_CentroCusto_IdCentroCusto",
                        column: x => x.IdCentroCusto,
                        principalTable: "CentroCusto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ConfiguracaoFinanceira_Clinica_IdClinica",
                        column: x => x.IdClinica,
                        principalTable: "Clinica",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ConfiguracaoFinanceira_ContaBancaria_IdContaBancaria",
                        column: x => x.IdContaBancaria,
                        principalTable: "ContaBancaria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ConfiguracaoFinanceira_FormaPagamento_IdFormaPagamento",
                        column: x => x.IdFormaPagamento,
                        principalTable: "FormaPagamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "lancamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataLancamento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataVencimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdPaciente = table.Column<int>(type: "int", nullable: false),
                    IdFuncionario = table.Column<int>(type: "int", nullable: false),
                    IdConvenio = table.Column<int>(type: "int", nullable: false),
                    IdProcedimento = table.Column<int>(type: "int", nullable: false),
                    IdSubCategoria = table.Column<int>(type: "int", nullable: false),
                    IdContaBancaria = table.Column<int>(type: "int", nullable: false),
                    IdFormaPagamento = table.Column<int>(type: "int", nullable: false),
                    IdCentroCusto = table.Column<int>(type: "int", nullable: false),
                    IdClinica = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lancamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_lancamento_CentroCusto_IdCentroCusto",
                        column: x => x.IdCentroCusto,
                        principalTable: "CentroCusto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_lancamento_Clinica_IdClinica",
                        column: x => x.IdClinica,
                        principalTable: "Clinica",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_lancamento_ContaBancaria_IdContaBancaria",
                        column: x => x.IdContaBancaria,
                        principalTable: "ContaBancaria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_lancamento_Convenio_IdConvenio",
                        column: x => x.IdConvenio,
                        principalTable: "Convenio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_lancamento_FormaPagamento_IdFormaPagamento",
                        column: x => x.IdFormaPagamento,
                        principalTable: "FormaPagamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_lancamento_Funcionario_IdFuncionario",
                        column: x => x.IdFuncionario,
                        principalTable: "Funcionario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_lancamento_Paciente_IdPaciente",
                        column: x => x.IdPaciente,
                        principalTable: "Paciente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_lancamento_Procedimento_IdProcedimento",
                        column: x => x.IdProcedimento,
                        principalTable: "Procedimento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_lancamento_SubCategoria_IdSubCategoria",
                        column: x => x.IdSubCategoria,
                        principalTable: "SubCategoria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Banco_IdClinica",
                table: "Banco",
                column: "IdClinica");

            migrationBuilder.CreateIndex(
                name: "IX_CategoriaFinanceira_IdClinica",
                table: "CategoriaFinanceira",
                column: "IdClinica");

            migrationBuilder.CreateIndex(
                name: "IX_CentroCusto_IdClinica",
                table: "CentroCusto",
                column: "IdClinica");

            migrationBuilder.CreateIndex(
                name: "IX_ConfiguracaoFinanceira_IdBanco",
                table: "ConfiguracaoFinanceira",
                column: "IdBanco");

            migrationBuilder.CreateIndex(
                name: "IX_ConfiguracaoFinanceira_IdCentroCusto",
                table: "ConfiguracaoFinanceira",
                column: "IdCentroCusto");

            migrationBuilder.CreateIndex(
                name: "IX_ConfiguracaoFinanceira_IdClinica",
                table: "ConfiguracaoFinanceira",
                column: "IdClinica");

            migrationBuilder.CreateIndex(
                name: "IX_ConfiguracaoFinanceira_IdContaBancaria",
                table: "ConfiguracaoFinanceira",
                column: "IdContaBancaria");

            migrationBuilder.CreateIndex(
                name: "IX_ConfiguracaoFinanceira_IdFormaPagamento",
                table: "ConfiguracaoFinanceira",
                column: "IdFormaPagamento");

            migrationBuilder.CreateIndex(
                name: "IX_ContaBancaria_IdBanco",
                table: "ContaBancaria",
                column: "IdBanco");

            migrationBuilder.CreateIndex(
                name: "IX_lancamento_IdCentroCusto",
                table: "lancamento",
                column: "IdCentroCusto");

            migrationBuilder.CreateIndex(
                name: "IX_lancamento_IdClinica",
                table: "lancamento",
                column: "IdClinica");

            migrationBuilder.CreateIndex(
                name: "IX_lancamento_IdContaBancaria",
                table: "lancamento",
                column: "IdContaBancaria");

            migrationBuilder.CreateIndex(
                name: "IX_lancamento_IdConvenio",
                table: "lancamento",
                column: "IdConvenio");

            migrationBuilder.CreateIndex(
                name: "IX_lancamento_IdFormaPagamento",
                table: "lancamento",
                column: "IdFormaPagamento");

            migrationBuilder.CreateIndex(
                name: "IX_lancamento_IdFuncionario",
                table: "lancamento",
                column: "IdFuncionario");

            migrationBuilder.CreateIndex(
                name: "IX_lancamento_IdPaciente",
                table: "lancamento",
                column: "IdPaciente");

            migrationBuilder.CreateIndex(
                name: "IX_lancamento_IdProcedimento",
                table: "lancamento",
                column: "IdProcedimento");

            migrationBuilder.CreateIndex(
                name: "IX_lancamento_IdSubCategoria",
                table: "lancamento",
                column: "IdSubCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategoria_IdCategoriaFinanceira",
                table: "SubCategoria",
                column: "IdCategoriaFinanceira");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConfiguracaoFinanceira");

            migrationBuilder.DropTable(
                name: "lancamento");

            migrationBuilder.DropTable(
                name: "CentroCusto");

            migrationBuilder.DropTable(
                name: "ContaBancaria");

            migrationBuilder.DropTable(
                name: "SubCategoria");

            migrationBuilder.DropTable(
                name: "Banco");

            migrationBuilder.DropTable(
                name: "CategoriaFinanceira");
        }
    }
}
