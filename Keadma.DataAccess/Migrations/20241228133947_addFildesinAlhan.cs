using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Keadma.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addFildesinAlhan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "attendance",
                table: "Alhan",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "committed",
                table: "Alhan",
                type: "bit",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "attendance",
                table: "Alhan");

            migrationBuilder.DropColumn(
                name: "committed",
                table: "Alhan");
        }
    }
}
