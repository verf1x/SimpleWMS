using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleWMS.Persistemce.Migrations
{
    /// <inheritdoc />
    public partial class AddReceivingPlacementAndShipping : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AssignedCrateId",
                table: "Instances",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "AssignedMobileContainerId",
                table: "Instances",
                type: "uniqueidentifier",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AssignedCrateId",
                table: "Instances");

            migrationBuilder.DropColumn(
                name: "AssignedMobileContainerId",
                table: "Instances");
        }
    }
}
