using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Keadma.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddActiveInUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "TBUser",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "TBUser");
        }
    }
}
