using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class MigrationAlteracaoTabelaUsuarioClinica : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agendamento_UsuarioClinica_IdUsuarioClinica",
                table: "Agendamento");

            migrationBuilder.DropTable(
                name: "UsuarioClinica");

            migrationBuilder.DropColumn(
                name: "HorarioFim",
                table: "Agendamento");

            migrationBuilder.DropColumn(
                name: "HorarioInicio",
                table: "Agendamento");

            migrationBuilder.RenameColumn(
                name: "IdUsuarioClinica",
                table: "Agendamento",
                newName: "IdFuncionario");

            migrationBuilder.RenameIndex(
                name: "IX_Agendamento_IdUsuarioClinica",
                table: "Agendamento",
                newName: "IX_Agendamento_IdFuncionario");

            migrationBuilder.CreateTable(
                name: "Funcionario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Perfil = table.Column<int>(type: "int", nullable: false),
                    RegistroProfissional = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Especialidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdClinica = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Funcionario_Clinica_IdClinica",
                        column: x => x.IdClinica,
                        principalTable: "Clinica",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Funcionario_IdClinica",
                table: "Funcionario",
                column: "IdClinica");

            migrationBuilder.AddForeignKey(
                name: "FK_Agendamento_Funcionario_IdFuncionario",
                table: "Agendamento",
                column: "IdFuncionario",
                principalTable: "Funcionario",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agendamento_Funcionario_IdFuncionario",
                table: "Agendamento");

            migrationBuilder.DropTable(
                name: "Funcionario");

            migrationBuilder.RenameColumn(
                name: "IdFuncionario",
                table: "Agendamento",
                newName: "IdUsuarioClinica");

            migrationBuilder.RenameIndex(
                name: "IX_Agendamento_IdFuncionario",
                table: "Agendamento",
                newName: "IX_Agendamento_IdUsuarioClinica");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "HorarioFim",
                table: "Agendamento",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "HorarioInicio",
                table: "Agendamento",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.CreateTable(
                name: "UsuarioClinica",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdClinica = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Especialidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Perfil = table.Column<int>(type: "int", nullable: false),
                    RegistroProfissional = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioClinica", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuarioClinica_Clinica_IdClinica",
                        column: x => x.IdClinica,
                        principalTable: "Clinica",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioClinica_IdClinica",
                table: "UsuarioClinica",
                column: "IdClinica");

            migrationBuilder.AddForeignKey(
                name: "FK_Agendamento_UsuarioClinica_IdUsuarioClinica",
                table: "Agendamento",
                column: "IdUsuarioClinica",
                principalTable: "UsuarioClinica",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
