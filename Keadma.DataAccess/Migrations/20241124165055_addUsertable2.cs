using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Keadma.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addUsertable2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TBUserRole",
                table: "TBUserRole");

            migrationBuilder.RenameTable(
                name: "TBUserRole",
                newName: "UserRole");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "UserRole",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRole",
                table: "UserRole",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleId",
                table: "UserRole",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRole_TBRole_RoleId",
                table: "UserRole",
                column: "RoleId",
                principalTable: "TBRole",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRole_TBUser_UserId",
                table: "UserRole",
                column: "UserId",
                principalTable: "TBUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRole_TBRole_RoleId",
                table: "UserRole");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRole_TBUser_UserId",
                table: "UserRole");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRole",
                table: "UserRole");

            migrationBuilder.DropIndex(
                name: "IX_UserRole_RoleId",
                table: "UserRole");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserRole");

            migrationBuilder.RenameTable(
                name: "UserRole",
                newName: "TBUserRole");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TBUserRole",
                table: "TBUserRole",
                columns: new[] { "UserId", "RoleId" });
        }
    }
}
