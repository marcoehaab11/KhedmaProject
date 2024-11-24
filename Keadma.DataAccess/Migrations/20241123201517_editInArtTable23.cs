using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Keadma.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class editInArtTable23 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Arts",
                table: "Arts");

            migrationBuilder.AlterColumn<int>(
                name: "InGroup",
                table: "Arts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Arts",
                table: "Arts",
                columns: new[] { "MakhdoumID", "StageID", "ArtID", "InGroup" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Arts",
                table: "Arts");

            migrationBuilder.AlterColumn<int>(
                name: "InGroup",
                table: "Arts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Arts",
                table: "Arts",
                columns: new[] { "MakhdoumID", "StageID", "ArtID" });
        }
    }
}
