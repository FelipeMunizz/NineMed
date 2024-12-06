using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class MigrationConfigClinica : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiaFim",
                table: "ConfiguracaoClinica");

            migrationBuilder.DropColumn(
                name: "DiaInicio",
                table: "ConfiguracaoClinica");

            migrationBuilder.RenameColumn(
                name: "IntervaloAgenda",
                table: "ConfiguracaoClinica",
                newName: "IntervaloAgendaPadrao");

            migrationBuilder.AlterColumn<TimeOnly>(
                name: "HorarioFechamento",
                table: "ConfiguracaoClinica",
                type: "time",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<TimeOnly>(
                name: "HorarioAbertura",
                table: "ConfiguracaoClinica",
                type: "time",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IntervaloAgendaPadrao",
                table: "ConfiguracaoClinica",
                newName: "IntervaloAgenda");

            migrationBuilder.AlterColumn<DateTime>(
                name: "HorarioFechamento",
                table: "ConfiguracaoClinica",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(TimeOnly),
                oldType: "time");

            migrationBuilder.AlterColumn<DateTime>(
                name: "HorarioAbertura",
                table: "ConfiguracaoClinica",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(TimeOnly),
                oldType: "time");

            migrationBuilder.AddColumn<int>(
                name: "DiaFim",
                table: "ConfiguracaoClinica",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DiaInicio",
                table: "ConfiguracaoClinica",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
