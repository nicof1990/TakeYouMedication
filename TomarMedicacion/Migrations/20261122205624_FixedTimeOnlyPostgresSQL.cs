using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TomarMedicacion.Migrations
{
    /// <inheritdoc />
    public partial class FixedTimeOnlyPostgresSQL : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeOnly>(
                name: "Horario",
                table: "Recordatorio",
                type: "time without time zone",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "interval");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeSpan>(
                name: "Horario",
                table: "Recordatorio",
                type: "interval",
                nullable: false,
                oldClrType: typeof(TimeOnly),
                oldType: "time without time zone");
        }
    }
}
