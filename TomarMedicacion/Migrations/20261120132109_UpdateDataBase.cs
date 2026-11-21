using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TomarMedicacion.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDataBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Paciente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Celular = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paciente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Recordatorio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PacienteId = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Horario = table.Column<TimeSpan>(type: "time", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recordatorio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recordatorio_Paciente_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Paciente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Dias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiasSemana = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecordatorioId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dias_Recordatorio_RecordatorioId",
                        column: x => x.RecordatorioId,
                        principalTable: "Recordatorio",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Medicacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dosis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecordatorioId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicacion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Medicacion_Recordatorio_RecordatorioId",
                        column: x => x.RecordatorioId,
                        principalTable: "Recordatorio",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dias_RecordatorioId",
                table: "Dias",
                column: "RecordatorioId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicacion_RecordatorioId",
                table: "Medicacion",
                column: "RecordatorioId");

            migrationBuilder.CreateIndex(
                name: "IX_Recordatorio_PacienteId",
                table: "Recordatorio",
                column: "PacienteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dias");

            migrationBuilder.DropTable(
                name: "Medicacion");

            migrationBuilder.DropTable(
                name: "Recordatorio");

            migrationBuilder.DropTable(
                name: "Paciente");
        }
    }
}
