using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleWMS.Persistemce.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCrateCargo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CargoId",
                table: "Crates",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CrateIds",
                table: "Cargoes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CargoId",
                table: "Crates");

            migrationBuilder.DropColumn(
                name: "CrateIds",
                table: "Cargoes");
        }
    }
}
