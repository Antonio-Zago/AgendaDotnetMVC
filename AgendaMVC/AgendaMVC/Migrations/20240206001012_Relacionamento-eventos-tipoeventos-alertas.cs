using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgendaMVC.Migrations
{
    /// <inheritdoc />
    public partial class Relacionamentoeventostipoeventosalertas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TipoEventoId",
                table: "Eventos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Alertas",
                columns: table => new
                {
                    AlertaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DataOcorrencia = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EventoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alertas", x => x.AlertaId);
                    table.ForeignKey(
                        name: "FK_Alertas_Eventos_EventoId",
                        column: x => x.EventoId,
                        principalTable: "Eventos",
                        principalColumn: "EventoId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TipoEventos",
                columns: table => new
                {
                    TipoEventoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cor = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Icone = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoEventos", x => x.TipoEventoId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_TipoEventoId",
                table: "Eventos",
                column: "TipoEventoId");

            migrationBuilder.CreateIndex(
                name: "IX_Alertas_EventoId",
                table: "Alertas",
                column: "EventoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Eventos_TipoEventos_TipoEventoId",
                table: "Eventos",
                column: "TipoEventoId",
                principalTable: "TipoEventos",
                principalColumn: "TipoEventoId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Eventos_TipoEventos_TipoEventoId",
                table: "Eventos");

            migrationBuilder.DropTable(
                name: "Alertas");

            migrationBuilder.DropTable(
                name: "TipoEventos");

            migrationBuilder.DropIndex(
                name: "IX_Eventos_TipoEventoId",
                table: "Eventos");

            migrationBuilder.DropColumn(
                name: "TipoEventoId",
                table: "Eventos");
        }
    }
}
