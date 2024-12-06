using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class MigrationAgendamentosTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdProcedimento",
                table: "Agendamento");

            migrationBuilder.CreateTable(
                name: "AgendamentoProcedimento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    IdAgendamento = table.Column<int>(type: "int", nullable: false),
                    IdProcedimento = table.Column<int>(type: "int", nullable: false),
                    ValorTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgendamentoProcedimento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AgendamentoProcedimento_Agendamento_IdAgendamento",
                        column: x => x.IdAgendamento,
                        principalTable: "Agendamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AgendamentoProcedimento_Procedimento_IdProcedimento",
                        column: x => x.IdProcedimento,
                        principalTable: "Procedimento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "FormaPagamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoValor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UtilizaTef = table.Column<bool>(type: "bit", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormaPagamento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AgendamentoPagamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdAgendamento = table.Column<int>(type: "int", nullable: false),
                    IdFormaPagamento = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Troco = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_AgendamentoProcedimento_IdAgendamento",
                table: "AgendamentoProcedimento",
                column: "IdAgendamento");

            migrationBuilder.CreateIndex(
                name: "IX_AgendamentoProcedimento_IdProcedimento",
                table: "AgendamentoProcedimento",
                column: "IdProcedimento");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AgendamentoPagamento");

            migrationBuilder.DropTable(
                name: "AgendamentoProcedimento");

            migrationBuilder.DropTable(
                name: "FormaPagamento");

            migrationBuilder.AddColumn<string>(
                name: "IdProcedimento",
                table: "Agendamento",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
