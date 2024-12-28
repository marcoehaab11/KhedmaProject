using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Keadma.DataAccess.Migrations
{
    public partial class attendanceAlhan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Points",
                table: "TBMakhdoum",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Ticket",
                table: "BooksAndSaves",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Alhan_attendance",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MakhdoumID = table.Column<int>(type: "int", nullable: false),
                    StageID = table.Column<int>(type: "int", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    attendance = table.Column<bool>(type: "bit", nullable: false),
                    committed = table.Column<bool>(type: "bit", nullable: false),
                    TheStageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alhan_attendance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alhan_attendance_TBMakhdoum_MakhdoumID",
                        column: x => x.MakhdoumID,
                        principalTable: "TBMakhdoum",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Alhan_attendance_TBTheStage_TheStageId",
                        column: x => x.TheStageId,
                        principalTable: "TBTheStage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alhan_attendance_MakhdoumID",
                table: "Alhan_attendance",
                column: "MakhdoumID");

            migrationBuilder.CreateIndex(
                name: "IX_Alhan_attendance_TheStageId",
                table: "Alhan_attendance",
                column: "TheStageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alhan_attendance");

            migrationBuilder.DropColumn(
                name: "Points",
                table: "TBMakhdoum");

            migrationBuilder.AlterColumn<bool>(
                name: "Ticket",
                table: "BooksAndSaves",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");
        }
    }
}
