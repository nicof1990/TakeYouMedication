using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TomarMedicacion.Migrations
{
    /// <inheritdoc />
    public partial class MigrationToPostgreSQL : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Medicacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "character varying(125)", maxLength: 125, nullable: true),
                    Dosis = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicacion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Paciente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Celular = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paciente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Recordatorio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PacienteId = table.Column<int>(type: "integer", nullable: false),
                    MedicacionId = table.Column<int>(type: "integer", nullable: false),
                    Nombre = table.Column<string>(type: "text", nullable: true),
                    Horario = table.Column<TimeSpan>(type: "interval", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ChatID = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recordatorio", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Medicacion");

            migrationBuilder.DropTable(
                name: "Paciente");

            migrationBuilder.DropTable(
                name: "Recordatorio");
        }
    }
}
