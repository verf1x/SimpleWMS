using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleWMS.Persistemce.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCrate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "MobileContainerId",
                table: "Crates",
                type: "uniqueidentifier",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MobileContainerId",
                table: "Crates");
        }
    }
}
