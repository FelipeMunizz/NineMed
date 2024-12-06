using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class MigrationTotenTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SenhaToten_Clinica_IdClinica",
                table: "SenhaToten");

            migrationBuilder.RenameColumn(
                name: "IdClinica",
                table: "SenhaToten",
                newName: "IdToten");

            migrationBuilder.RenameIndex(
                name: "IX_SenhaToten_IdClinica",
                table: "SenhaToten",
                newName: "IX_SenhaToten_IdToten");

            migrationBuilder.CreateTable(
                name: "Toten",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdClinica = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Toten", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Toten_Clinica_IdClinica",
                        column: x => x.IdClinica,
                        principalTable: "Clinica",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Toten_IdClinica",
                table: "Toten",
                column: "IdClinica");

            migrationBuilder.AddForeignKey(
                name: "FK_SenhaToten_Toten_IdToten",
                table: "SenhaToten",
                column: "IdToten",
                principalTable: "Toten",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SenhaToten_Toten_IdToten",
                table: "SenhaToten");

            migrationBuilder.DropTable(
                name: "Toten");

            migrationBuilder.RenameColumn(
                name: "IdToten",
                table: "SenhaToten",
                newName: "IdClinica");

            migrationBuilder.RenameIndex(
                name: "IX_SenhaToten_IdToten",
                table: "SenhaToten",
                newName: "IX_SenhaToten_IdClinica");

            migrationBuilder.AddForeignKey(
                name: "FK_SenhaToten_Clinica_IdClinica",
                table: "SenhaToten",
                column: "IdClinica",
                principalTable: "Clinica",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
