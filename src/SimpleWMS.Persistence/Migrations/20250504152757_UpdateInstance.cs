using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleWMS.Persistemce.Migrations
{
    /// <inheritdoc />
    public partial class UpdateInstance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SortType",
                table: "Instances",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SortType",
                table: "Instances");
        }
    }
}
