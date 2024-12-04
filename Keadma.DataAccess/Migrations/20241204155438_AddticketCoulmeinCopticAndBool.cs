using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Keadma.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddticketCoulmeinCopticAndBool : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Ticket",
                table: "Coptic",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Ticket",
                table: "BooksAndSaves",
                type: "bit",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ticket",
                table: "Coptic");

            migrationBuilder.DropColumn(
                name: "Ticket",
                table: "BooksAndSaves");
        }
    }
}
