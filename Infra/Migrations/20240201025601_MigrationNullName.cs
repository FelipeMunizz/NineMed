using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class MigrationNullName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AgendamentoProcedimento_Agendamento_IdAgendamento",
                table: "AgendamentoProcedimento");

            migrationBuilder.DropTable(
                name: "AgendamentoPagamento");

            migrationBuilder.RenameColumn(
                name: "IdAgendamento",
                table: "AgendamentoProcedimento",
                newName: "IdAtendimento");

            migrationBuilder.RenameIndex(
                name: "IX_AgendamentoProcedimento_IdAgendamento",
                table: "AgendamentoProcedimento",
                newName: "IX_AgendamentoProcedimento_IdAtendimento");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Toten",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Procedimento",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "PlanosConvenio",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "PacienteFamiliar",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Paciente",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Funcionario",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "FormaPagamento",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Convenio",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "ContatoPaciente",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "ContatoClinica",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Clinica",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "IdConvenio",
                table: "Agendamento",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "IdsProcedimento",
                table: "Agendamento",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Atendimento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QueixaPrincipal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HistoriaMolestiaAtual = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HistoricoAntecedentes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExameFisico = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IMC = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Diagnostico = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Conduta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Finalizado = table.Column<bool>(type: "bit", nullable: false),
                    IdAgendamento = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atendimento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Atendimento_Agendamento_IdAgendamento",
                        column: x => x.IdAgendamento,
                        principalTable: "Agendamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProntuarioPaciente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AntecedenteClinico = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AntecedenteCirurgico = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AntecedenteFamiliares = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Habitos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Alergias = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MedicamentoUso = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdPaciente = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProntuarioPaciente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProntuarioPaciente_Paciente_IdPaciente",
                        column: x => x.IdPaciente,
                        principalTable: "Paciente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnexosAtendimento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Base64Anexo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdAtendimento = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnexosAtendimento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnexosAtendimento_Atendimento_IdAtendimento",
                        column: x => x.IdAtendimento,
                        principalTable: "Atendimento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AtestadoAtendimento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoAtestado = table.Column<int>(type: "int", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdAtendimento = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AtestadoAtendimento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AtestadoAtendimento_Atendimento_IdAtendimento",
                        column: x => x.IdAtendimento,
                        principalTable: "Atendimento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExameAtendimento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Exame = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    IdAtendimento = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExameAtendimento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExameAtendimento_Atendimento_IdAtendimento",
                        column: x => x.IdAtendimento,
                        principalTable: "Atendimento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PrescricaoAtendimento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoPrescricao = table.Column<int>(type: "int", nullable: false),
                    ItemReceita = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdAtendimento = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrescricaoAtendimento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrescricaoAtendimento_Atendimento_IdAtendimento",
                        column: x => x.IdAtendimento,
                        principalTable: "Atendimento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agendamento_IdConvenio",
                table: "Agendamento",
                column: "IdConvenio");

            migrationBuilder.CreateIndex(
                name: "IX_AnexosAtendimento_IdAtendimento",
                table: "AnexosAtendimento",
                column: "IdAtendimento");

            migrationBuilder.CreateIndex(
                name: "IX_Atendimento_IdAgendamento",
                table: "Atendimento",
                column: "IdAgendamento");

            migrationBuilder.CreateIndex(
                name: "IX_AtestadoAtendimento_IdAtendimento",
                table: "AtestadoAtendimento",
                column: "IdAtendimento");

            migrationBuilder.CreateIndex(
                name: "IX_ExameAtendimento_IdAtendimento",
                table: "ExameAtendimento",
                column: "IdAtendimento");

            migrationBuilder.CreateIndex(
                name: "IX_PrescricaoAtendimento_IdAtendimento",
                table: "PrescricaoAtendimento",
                column: "IdAtendimento");

            migrationBuilder.CreateIndex(
                name: "IX_ProntuarioPaciente_IdPaciente",
                table: "ProntuarioPaciente",
                column: "IdPaciente");

            migrationBuilder.AddForeignKey(
                name: "FK_Agendamento_Convenio_IdConvenio",
                table: "Agendamento",
                column: "IdConvenio",
                principalTable: "Convenio",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_AgendamentoProcedimento_Atendimento_IdAtendimento",
                table: "AgendamentoProcedimento",
                column: "IdAtendimento",
                principalTable: "Atendimento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agendamento_Convenio_IdConvenio",
                table: "Agendamento");

            migrationBuilder.DropForeignKey(
                name: "FK_AgendamentoProcedimento_Atendimento_IdAtendimento",
                table: "AgendamentoProcedimento");

            migrationBuilder.DropTable(
                name: "AnexosAtendimento");

            migrationBuilder.DropTable(
                name: "AtestadoAtendimento");

            migrationBuilder.DropTable(
                name: "ExameAtendimento");

            migrationBuilder.DropTable(
                name: "PrescricaoAtendimento");

            migrationBuilder.DropTable(
                name: "ProntuarioPaciente");

            migrationBuilder.DropTable(
                name: "Atendimento");

            migrationBuilder.DropIndex(
                name: "IX_Agendamento_IdConvenio",
                table: "Agendamento");

            migrationBuilder.DropColumn(
                name: "IdConvenio",
                table: "Agendamento");

            migrationBuilder.DropColumn(
                name: "IdsProcedimento",
                table: "Agendamento");

            migrationBuilder.RenameColumn(
                name: "IdAtendimento",
                table: "AgendamentoProcedimento",
                newName: "IdAgendamento");

            migrationBuilder.RenameIndex(
                name: "IX_AgendamentoProcedimento_IdAtendimento",
                table: "AgendamentoProcedimento",
                newName: "IX_AgendamentoProcedimento_IdAgendamento");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Toten",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Procedimento",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "PlanosConvenio",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "PacienteFamiliar",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Paciente",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Funcionario",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "FormaPagamento",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Convenio",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "ContatoPaciente",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "ContatoClinica",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Clinica",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "AgendamentoPagamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdAgendamento = table.Column<int>(type: "int", nullable: false),
                    IdFormaPagamento = table.Column<int>(type: "int", nullable: false),
                    Acrescimo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Desconto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Troco = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgendamentoPagamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AgendamentoPagamento_Agendamento_IdAgendamento",
                        column: x => x.IdAgendamento,
                        principalTable: "Agendamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AgendamentoPagamento_FormaPagamento_IdFormaPagamento",
                        column: x => x.IdFormaPagamento,
                        principalTable: "FormaPagamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AgendamentoPagamento_IdAgendamento",
                table: "AgendamentoPagamento",
                column: "IdAgendamento");

            migrationBuilder.CreateIndex(
                name: "IX_AgendamentoPagamento_IdFormaPagamento",
                table: "AgendamentoPagamento",
                column: "IdFormaPagamento");

            migrationBuilder.AddForeignKey(
                name: "FK_AgendamentoProcedimento_Agendamento_IdAgendamento",
                table: "AgendamentoProcedimento",
                column: "IdAgendamento",
                principalTable: "Agendamento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
