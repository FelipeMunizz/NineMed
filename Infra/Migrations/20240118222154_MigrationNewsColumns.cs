using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class MigrationNewsColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agendamento_Clinica_IdClinica",
                table: "Agendamento");

            migrationBuilder.DropForeignKey(
                name: "FK_Agendamento_Funcionario_IdFuncionario",
                table: "Agendamento");

            migrationBuilder.DropForeignKey(
                name: "FK_Agendamento_Paciente_IdPaciente",
                table: "Agendamento");

            migrationBuilder.DropForeignKey(
                name: "FK_AgendamentoPagamento_Agendamento_IdAgendamento",
                table: "AgendamentoPagamento");

            migrationBuilder.DropForeignKey(
                name: "FK_AgendamentoPagamento_FormaPagamento_IdFormaPagamento",
                table: "AgendamentoPagamento");

            migrationBuilder.DropForeignKey(
                name: "FK_AgendamentoProcedimento_Agendamento_IdAgendamento",
                table: "AgendamentoProcedimento");

            migrationBuilder.DropForeignKey(
                name: "FK_AgendamentoProcedimento_Procedimento_IdProcedimento",
                table: "AgendamentoProcedimento");

            migrationBuilder.DropForeignKey(
                name: "FK_ConfiguracaoClinica_Clinica_IdClinica",
                table: "ConfiguracaoClinica");

            migrationBuilder.DropForeignKey(
                name: "FK_ContatoClinica_Clinica_IdClinica",
                table: "ContatoClinica");

            migrationBuilder.DropForeignKey(
                name: "FK_ContatoPaciente_Paciente_IdPaciente",
                table: "ContatoPaciente");

            migrationBuilder.DropForeignKey(
                name: "FK_Convenio_Clinica_IdClinica",
                table: "Convenio");

            migrationBuilder.DropForeignKey(
                name: "FK_EnderecoClinica_Clinica_IdClinica",
                table: "EnderecoClinica");

            migrationBuilder.DropForeignKey(
                name: "FK_EnderecoPaciente_Paciente_IdPaciente",
                table: "EnderecoPaciente");

            migrationBuilder.DropForeignKey(
                name: "FK_FormaPagamento_Clinica_IdClinica",
                table: "FormaPagamento");

            migrationBuilder.DropForeignKey(
                name: "FK_Funcionario_Clinica_IdClinica",
                table: "Funcionario");

            migrationBuilder.DropForeignKey(
                name: "FK_HorarioFuncionario_Funcionario_IdFuncionario",
                table: "HorarioFuncionario");

            migrationBuilder.DropForeignKey(
                name: "FK_Paciente_Clinica_IdClinica",
                table: "Paciente");

            migrationBuilder.DropForeignKey(
                name: "FK_PacienteConvenio_Paciente_IdPaciente",
                table: "PacienteConvenio");

            migrationBuilder.DropForeignKey(
                name: "FK_PacienteFamiliar_Paciente_IdPaciente",
                table: "PacienteFamiliar");

            migrationBuilder.DropForeignKey(
                name: "FK_Procedimento_Clinica_IdClinica",
                table: "Procedimento");

            migrationBuilder.DropForeignKey(
                name: "FK_SenhaToten_Toten_IdToten",
                table: "SenhaToten");

            migrationBuilder.DropForeignKey(
                name: "FK_Toten_Clinica_IdClinica",
                table: "Toten");

            migrationBuilder.DropIndex(
                name: "IX_Toten_IdClinica",
                table: "Toten");

            migrationBuilder.DropIndex(
                name: "IX_SenhaToten_IdToten",
                table: "SenhaToten");

            migrationBuilder.DropIndex(
                name: "IX_Procedimento_IdClinica",
                table: "Procedimento");

            migrationBuilder.DropIndex(
                name: "IX_PacienteFamiliar_IdPaciente",
                table: "PacienteFamiliar");

            migrationBuilder.DropIndex(
                name: "IX_PacienteConvenio_IdPaciente",
                table: "PacienteConvenio");

            migrationBuilder.DropIndex(
                name: "IX_Paciente_IdClinica",
                table: "Paciente");

            migrationBuilder.DropIndex(
                name: "IX_HorarioFuncionario_IdFuncionario",
                table: "HorarioFuncionario");

            migrationBuilder.DropIndex(
                name: "IX_Funcionario_IdClinica",
                table: "Funcionario");

            migrationBuilder.DropIndex(
                name: "IX_FormaPagamento_IdClinica",
                table: "FormaPagamento");

            migrationBuilder.DropIndex(
                name: "IX_EnderecoPaciente_IdPaciente",
                table: "EnderecoPaciente");

            migrationBuilder.DropIndex(
                name: "IX_EnderecoClinica_IdClinica",
                table: "EnderecoClinica");

            migrationBuilder.DropIndex(
                name: "IX_Convenio_IdClinica",
                table: "Convenio");

            migrationBuilder.DropIndex(
                name: "IX_ContatoPaciente_IdPaciente",
                table: "ContatoPaciente");

            migrationBuilder.DropIndex(
                name: "IX_ContatoClinica_IdClinica",
                table: "ContatoClinica");

            migrationBuilder.DropIndex(
                name: "IX_ConfiguracaoClinica_IdClinica",
                table: "ConfiguracaoClinica");

            migrationBuilder.DropIndex(
                name: "IX_AgendamentoProcedimento_IdAgendamento",
                table: "AgendamentoProcedimento");

            migrationBuilder.DropIndex(
                name: "IX_AgendamentoProcedimento_IdProcedimento",
                table: "AgendamentoProcedimento");

            migrationBuilder.DropIndex(
                name: "IX_AgendamentoPagamento_IdAgendamento",
                table: "AgendamentoPagamento");

            migrationBuilder.DropIndex(
                name: "IX_AgendamentoPagamento_IdFormaPagamento",
                table: "AgendamentoPagamento");

            migrationBuilder.DropIndex(
                name: "IX_Agendamento_IdClinica",
                table: "Agendamento");

            migrationBuilder.DropIndex(
                name: "IX_Agendamento_IdFuncionario",
                table: "Agendamento");

            migrationBuilder.DropIndex(
                name: "IX_Agendamento_IdPaciente",
                table: "Agendamento");

            migrationBuilder.AddColumn<string>(
                name: "CodTribMunicipio",
                table: "Procedimento",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CodMunicipio",
                table: "EnderecoPaciente",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CodMunicipio",
                table: "EnderecoClinica",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CNAE",
                table: "ConfiguracaoClinica",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "NumeroNota",
                table: "ConfiguracaoClinica",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CodTribMunicipio",
                table: "Procedimento");

            migrationBuilder.DropColumn(
                name: "CodMunicipio",
                table: "EnderecoPaciente");

            migrationBuilder.DropColumn(
                name: "CodMunicipio",
                table: "EnderecoClinica");

            migrationBuilder.DropColumn(
                name: "CNAE",
                table: "ConfiguracaoClinica");

            migrationBuilder.DropColumn(
                name: "NumeroNota",
                table: "ConfiguracaoClinica");

            migrationBuilder.CreateIndex(
                name: "IX_Toten_IdClinica",
                table: "Toten",
                column: "IdClinica");

            migrationBuilder.CreateIndex(
                name: "IX_SenhaToten_IdToten",
                table: "SenhaToten",
                column: "IdToten");

            migrationBuilder.CreateIndex(
                name: "IX_Procedimento_IdClinica",
                table: "Procedimento",
                column: "IdClinica");

            migrationBuilder.CreateIndex(
                name: "IX_PacienteFamiliar_IdPaciente",
                table: "PacienteFamiliar",
                column: "IdPaciente");

            migrationBuilder.CreateIndex(
                name: "IX_PacienteConvenio_IdPaciente",
                table: "PacienteConvenio",
                column: "IdPaciente");

            migrationBuilder.CreateIndex(
                name: "IX_Paciente_IdClinica",
                table: "Paciente",
                column: "IdClinica");

            migrationBuilder.CreateIndex(
                name: "IX_HorarioFuncionario_IdFuncionario",
                table: "HorarioFuncionario",
                column: "IdFuncionario");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionario_IdClinica",
                table: "Funcionario",
                column: "IdClinica");

            migrationBuilder.CreateIndex(
                name: "IX_FormaPagamento_IdClinica",
                table: "FormaPagamento",
                column: "IdClinica");

            migrationBuilder.CreateIndex(
                name: "IX_EnderecoPaciente_IdPaciente",
                table: "EnderecoPaciente",
                column: "IdPaciente");

            migrationBuilder.CreateIndex(
                name: "IX_EnderecoClinica_IdClinica",
                table: "EnderecoClinica",
                column: "IdClinica");

            migrationBuilder.CreateIndex(
                name: "IX_Convenio_IdClinica",
                table: "Convenio",
                column: "IdClinica");

            migrationBuilder.CreateIndex(
                name: "IX_ContatoPaciente_IdPaciente",
                table: "ContatoPaciente",
                column: "IdPaciente");

            migrationBuilder.CreateIndex(
                name: "IX_ContatoClinica_IdClinica",
                table: "ContatoClinica",
                column: "IdClinica");

            migrationBuilder.CreateIndex(
                name: "IX_ConfiguracaoClinica_IdClinica",
                table: "ConfiguracaoClinica",
                column: "IdClinica");

            migrationBuilder.CreateIndex(
                name: "IX_AgendamentoProcedimento_IdAgendamento",
                table: "AgendamentoProcedimento",
                column: "IdAgendamento");

            migrationBuilder.CreateIndex(
                name: "IX_AgendamentoProcedimento_IdProcedimento",
                table: "AgendamentoProcedimento",
                column: "IdProcedimento");

            migrationBuilder.CreateIndex(
                name: "IX_AgendamentoPagamento_IdAgendamento",
                table: "AgendamentoPagamento",
                column: "IdAgendamento");

            migrationBuilder.CreateIndex(
                name: "IX_AgendamentoPagamento_IdFormaPagamento",
                table: "AgendamentoPagamento",
                column: "IdFormaPagamento");

            migrationBuilder.CreateIndex(
                name: "IX_Agendamento_IdClinica",
                table: "Agendamento",
                column: "IdClinica");

            migrationBuilder.CreateIndex(
                name: "IX_Agendamento_IdFuncionario",
                table: "Agendamento",
                column: "IdFuncionario");

            migrationBuilder.CreateIndex(
                name: "IX_Agendamento_IdPaciente",
                table: "Agendamento",
                column: "IdPaciente");

            migrationBuilder.AddForeignKey(
                name: "FK_Agendamento_Clinica_IdClinica",
                table: "Agendamento",
                column: "IdClinica",
                principalTable: "Clinica",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Agendamento_Funcionario_IdFuncionario",
                table: "Agendamento",
                column: "IdFuncionario",
                principalTable: "Funcionario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Agendamento_Paciente_IdPaciente",
                table: "Agendamento",
                column: "IdPaciente",
                principalTable: "Paciente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AgendamentoPagamento_Agendamento_IdAgendamento",
                table: "AgendamentoPagamento",
                column: "IdAgendamento",
                principalTable: "Agendamento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AgendamentoPagamento_FormaPagamento_IdFormaPagamento",
                table: "AgendamentoPagamento",
                column: "IdFormaPagamento",
                principalTable: "FormaPagamento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AgendamentoProcedimento_Agendamento_IdAgendamento",
                table: "AgendamentoProcedimento",
                column: "IdAgendamento",
                principalTable: "Agendamento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AgendamentoProcedimento_Procedimento_IdProcedimento",
                table: "AgendamentoProcedimento",
                column: "IdProcedimento",
                principalTable: "Procedimento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ConfiguracaoClinica_Clinica_IdClinica",
                table: "ConfiguracaoClinica",
                column: "IdClinica",
                principalTable: "Clinica",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ContatoClinica_Clinica_IdClinica",
                table: "ContatoClinica",
                column: "IdClinica",
                principalTable: "Clinica",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ContatoPaciente_Paciente_IdPaciente",
                table: "ContatoPaciente",
                column: "IdPaciente",
                principalTable: "Paciente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Convenio_Clinica_IdClinica",
                table: "Convenio",
                column: "IdClinica",
                principalTable: "Clinica",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EnderecoClinica_Clinica_IdClinica",
                table: "EnderecoClinica",
                column: "IdClinica",
                principalTable: "Clinica",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EnderecoPaciente_Paciente_IdPaciente",
                table: "EnderecoPaciente",
                column: "IdPaciente",
                principalTable: "Paciente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FormaPagamento_Clinica_IdClinica",
                table: "FormaPagamento",
                column: "IdClinica",
                principalTable: "Clinica",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionario_Clinica_IdClinica",
                table: "Funcionario",
                column: "IdClinica",
                principalTable: "Clinica",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HorarioFuncionario_Funcionario_IdFuncionario",
                table: "HorarioFuncionario",
                column: "IdFuncionario",
                principalTable: "Funcionario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Paciente_Clinica_IdClinica",
                table: "Paciente",
                column: "IdClinica",
                principalTable: "Clinica",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Procedimento_Clinica_IdClinica",
                table: "Procedimento",
                column: "IdClinica",
                principalTable: "Clinica",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SenhaToten_Toten_IdToten",
                table: "SenhaToten",
                column: "IdToten",
                principalTable: "Toten",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Toten_Clinica_IdClinica",
                table: "Toten",
                column: "IdClinica",
                principalTable: "Clinica",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
