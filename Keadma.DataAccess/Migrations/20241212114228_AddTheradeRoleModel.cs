using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Keadma.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddTheradeRoleModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Theater",
                table: "Theater");

            migrationBuilder.AddColumn<int>(
                name: "RoleID",
                table: "Theater",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Theater",
                table: "Theater",
                columns: new[] { "MakhdoumID", "StageID", "RoleID" });

            migrationBuilder.CreateTable(
                name: "TheaterRole",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TheaterRole", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Theater_RoleID",
                table: "Theater",
                column: "RoleID");

            migrationBuilder.AddForeignKey(
                name: "FK_Theater_TheaterRole_RoleID",
                table: "Theater",
                column: "RoleID",
                principalTable: "TheaterRole",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Theater_TheaterRole_RoleID",
                table: "Theater");

            migrationBuilder.DropTable(
                name: "TheaterRole");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Theater",
                table: "Theater");

            migrationBuilder.DropIndex(
                name: "IX_Theater_RoleID",
                table: "Theater");

            migrationBuilder.DropColumn(
                name: "RoleID",
                table: "Theater");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Theater",
                table: "Theater",
                columns: new[] { "MakhdoumID", "StageID" });
        }
    }
}
