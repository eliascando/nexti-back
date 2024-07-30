using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace nexti.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class _002 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Descripción",
                table: "Eventos",
                newName: "Descripcion");

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Usuarios",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaElimina",
                table: "Eventos",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UsuarioElimina",
                table: "Eventos",
                type: "bigint",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "FechaElimina",
                table: "Eventos");

            migrationBuilder.DropColumn(
                name: "UsuarioElimina",
                table: "Eventos");

            migrationBuilder.RenameColumn(
                name: "Descripcion",
                table: "Eventos",
                newName: "Descripción");
        }
    }
}
