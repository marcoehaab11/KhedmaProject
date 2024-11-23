using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Keadma.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class editInArtsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Arts",
                table: "Arts");

            migrationBuilder.AddColumn<int>(
                name: "ArtID",
                table: "Arts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Arts",
                table: "Arts",
                columns: new[] { "MakhdoumID", "StageID", "ArtID" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Arts",
                table: "Arts");

            migrationBuilder.DropColumn(
                name: "ArtID",
                table: "Arts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Arts",
                table: "Arts",
                columns: new[] { "MakhdoumID", "StageID" });
        }
    }
}
