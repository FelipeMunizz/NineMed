using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class MigrationTempoAgendado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<TimeOnly>(
                name: "TempoAgendado",
                table: "HorarioFuncionario",
                type: "time",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TempoAgendado",
                table: "HorarioFuncionario");
        }
    }
}
