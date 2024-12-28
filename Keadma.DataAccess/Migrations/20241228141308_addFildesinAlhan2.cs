using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Keadma.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addFildesinAlhan2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alhan_attendance_TBTheStage_TheStageId",
                table: "Alhan_attendance");

            migrationBuilder.DropIndex(
                name: "IX_Alhan_attendance_TheStageId",
                table: "Alhan_attendance");

            migrationBuilder.DropColumn(
                name: "TheStageId",
                table: "Alhan_attendance");

            migrationBuilder.CreateIndex(
                name: "IX_Alhan_attendance_StageID",
                table: "Alhan_attendance",
                column: "StageID");

            migrationBuilder.AddForeignKey(
                name: "FK_Alhan_attendance_TBTheStage_StageID",
                table: "Alhan_attendance",
                column: "StageID",
                principalTable: "TBTheStage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alhan_attendance_TBTheStage_StageID",
                table: "Alhan_attendance");

            migrationBuilder.DropIndex(
                name: "IX_Alhan_attendance_StageID",
                table: "Alhan_attendance");

            migrationBuilder.AddColumn<int>(
                name: "TheStageId",
                table: "Alhan_attendance",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Alhan_attendance_TheStageId",
                table: "Alhan_attendance",
                column: "TheStageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alhan_attendance_TBTheStage_TheStageId",
                table: "Alhan_attendance",
                column: "TheStageId",
                principalTable: "TBTheStage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
