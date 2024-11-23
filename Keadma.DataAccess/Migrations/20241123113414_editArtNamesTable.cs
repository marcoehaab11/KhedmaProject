using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Keadma.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class editArtNamesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Arts_TBArtsName_StageID",
                table: "Arts");

            migrationBuilder.CreateIndex(
                name: "IX_Arts_ArtID",
                table: "Arts",
                column: "ArtID");

            migrationBuilder.AddForeignKey(
                name: "FK_Arts_TBArtsName_ArtID",
                table: "Arts",
                column: "ArtID",
                principalTable: "TBArtsName",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Arts_TBArtsName_ArtID",
                table: "Arts");

            migrationBuilder.DropIndex(
                name: "IX_Arts_ArtID",
                table: "Arts");

            migrationBuilder.AddForeignKey(
                name: "FK_Arts_TBArtsName_StageID",
                table: "Arts",
                column: "StageID",
                principalTable: "TBArtsName",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
