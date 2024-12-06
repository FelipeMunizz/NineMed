using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class MigrationTeste : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lancamento_CentroCusto_IdCentroCusto",
                table: "Lancamento");

            migrationBuilder.DropForeignKey(
                name: "FK_Lancamento_Convenio_IdConvenio",
                table: "Lancamento");

            migrationBuilder.DropForeignKey(
                name: "FK_Lancamento_Paciente_IdPaciente",
                table: "Lancamento");

            migrationBuilder.DropForeignKey(
                name: "FK_Lancamento_Procedimento_IdProcedimento",
                table: "Lancamento");

            migrationBuilder.AlterColumn<int>(
                name: "IdProcedimento",
                table: "Lancamento",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "IdPaciente",
                table: "Lancamento",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "IdConvenio",
                table: "Lancamento",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "IdCentroCusto",
                table: "Lancamento",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Lancamento_CentroCusto_IdCentroCusto",
                table: "Lancamento",
                column: "IdCentroCusto",
                principalTable: "CentroCusto",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Lancamento_Convenio_IdConvenio",
                table: "Lancamento",
                column: "IdConvenio",
                principalTable: "Convenio",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Lancamento_Paciente_IdPaciente",
                table: "Lancamento",
                column: "IdPaciente",
                principalTable: "Paciente",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Lancamento_Procedimento_IdProcedimento",
                table: "Lancamento",
                column: "IdProcedimento",
                principalTable: "Procedimento",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lancamento_CentroCusto_IdCentroCusto",
                table: "Lancamento");

            migrationBuilder.DropForeignKey(
                name: "FK_Lancamento_Convenio_IdConvenio",
                table: "Lancamento");

            migrationBuilder.DropForeignKey(
                name: "FK_Lancamento_Paciente_IdPaciente",
                table: "Lancamento");

            migrationBuilder.DropForeignKey(
                name: "FK_Lancamento_Procedimento_IdProcedimento",
                table: "Lancamento");

            migrationBuilder.AlterColumn<int>(
                name: "IdProcedimento",
                table: "Lancamento",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IdPaciente",
                table: "Lancamento",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IdConvenio",
                table: "Lancamento",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IdCentroCusto",
                table: "Lancamento",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Lancamento_CentroCusto_IdCentroCusto",
                table: "Lancamento",
                column: "IdCentroCusto",
                principalTable: "CentroCusto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Lancamento_Convenio_IdConvenio",
                table: "Lancamento",
                column: "IdConvenio",
                principalTable: "Convenio",
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
        }
    }
}
