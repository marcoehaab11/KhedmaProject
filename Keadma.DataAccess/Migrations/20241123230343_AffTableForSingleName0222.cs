using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Keadma.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AffTableForSingleName0222 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SingleNameId",
                table: "ForSingle",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ForSingle_SingleNameId",
                table: "ForSingle",
                column: "SingleNameId");

            migrationBuilder.AddForeignKey(
                name: "FK_ForSingle_TBForSingleName_SingleNameId",
                table: "ForSingle",
                column: "SingleNameId",
                principalTable: "TBForSingleName",
                principalColumn: "ForSingleNameId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ForSingle_TBForSingleName_SingleNameId",
                table: "ForSingle");

            migrationBuilder.DropIndex(
                name: "IX_ForSingle_SingleNameId",
                table: "ForSingle");

            migrationBuilder.DropColumn(
                name: "SingleNameId",
                table: "ForSingle");
        }
    }
}
