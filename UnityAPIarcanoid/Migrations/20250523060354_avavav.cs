using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UnityAPIarcanoid.Migrations
{
    /// <inheritdoc />
    public partial class avavav : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Points",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Points",
                table: "User");
        }
    }
}
