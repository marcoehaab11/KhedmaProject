using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Keadma.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addCopticAndBookAndSaqveAddenace : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "attendance",
                table: "Coptic",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "committed",
                table: "Coptic",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "excellence",
                table: "Coptic",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "attendance",
                table: "BooksAndSaves",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "committed",
                table: "BooksAndSaves",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "excellence",
                table: "BooksAndSaves",
                type: "bit",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BookAndSaves_attendance",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MakhdoumID = table.Column<int>(type: "int", nullable: false),
                    StageID = table.Column<int>(type: "int", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    attendance = table.Column<bool>(type: "bit", nullable: false),
                    committed = table.Column<bool>(type: "bit", nullable: false),
                    excellence = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookAndSaves_attendance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookAndSaves_attendance_TBMakhdoum_MakhdoumID",
                        column: x => x.MakhdoumID,
                        principalTable: "TBMakhdoum",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookAndSaves_attendance_TBTheStage_StageID",
                        column: x => x.StageID,
                        principalTable: "TBTheStage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Coptic_attendance",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MakhdoumID = table.Column<int>(type: "int", nullable: false),
                    StageID = table.Column<int>(type: "int", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    attendance = table.Column<bool>(type: "bit", nullable: false),
                    committed = table.Column<bool>(type: "bit", nullable: false),
                    excellence = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coptic_attendance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Coptic_attendance_TBMakhdoum_MakhdoumID",
                        column: x => x.MakhdoumID,
                        principalTable: "TBMakhdoum",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Coptic_attendance_TBTheStage_StageID",
                        column: x => x.StageID,
                        principalTable: "TBTheStage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookAndSaves_attendance_MakhdoumID",
                table: "BookAndSaves_attendance",
                column: "MakhdoumID");

            migrationBuilder.CreateIndex(
                name: "IX_BookAndSaves_attendance_StageID",
                table: "BookAndSaves_attendance",
                column: "StageID");

            migrationBuilder.CreateIndex(
                name: "IX_Coptic_attendance_MakhdoumID",
                table: "Coptic_attendance",
                column: "MakhdoumID");

            migrationBuilder.CreateIndex(
                name: "IX_Coptic_attendance_StageID",
                table: "Coptic_attendance",
                column: "StageID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookAndSaves_attendance");

            migrationBuilder.DropTable(
                name: "Coptic_attendance");

            migrationBuilder.DropColumn(
                name: "attendance",
                table: "Coptic");

            migrationBuilder.DropColumn(
                name: "committed",
                table: "Coptic");

            migrationBuilder.DropColumn(
                name: "excellence",
                table: "Coptic");

            migrationBuilder.DropColumn(
                name: "attendance",
                table: "BooksAndSaves");

            migrationBuilder.DropColumn(
                name: "committed",
                table: "BooksAndSaves");

            migrationBuilder.DropColumn(
                name: "excellence",
                table: "BooksAndSaves");
        }
    }
}
