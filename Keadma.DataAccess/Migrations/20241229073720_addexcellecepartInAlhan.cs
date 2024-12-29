using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Keadma.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addexcellecepartInAlhan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "excellence",
                table: "Alhan_attendance",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "excellence",
                table: "Alhan",
                type: "bit",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "excellence",
                table: "Alhan_attendance");

            migrationBuilder.DropColumn(
                name: "excellence",
                table: "Alhan");
        }
    }
}
