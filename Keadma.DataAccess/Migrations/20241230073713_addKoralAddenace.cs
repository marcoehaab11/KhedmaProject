using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Keadma.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addKoralAddenace : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "attendance",
                table: "Tbkoral",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "committed",
                table: "Tbkoral",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "excellence",
                table: "Tbkoral",
                type: "bit",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Koral_attendance",
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
                    table.PrimaryKey("PK_Koral_attendance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Koral_attendance_TBMakhdoum_MakhdoumID",
                        column: x => x.MakhdoumID,
                        principalTable: "TBMakhdoum",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Koral_attendance_TBTheStage_StageID",
                        column: x => x.StageID,
                        principalTable: "TBTheStage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Koral_attendance_MakhdoumID",
                table: "Koral_attendance",
                column: "MakhdoumID");

            migrationBuilder.CreateIndex(
                name: "IX_Koral_attendance_StageID",
                table: "Koral_attendance",
                column: "StageID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Koral_attendance");

            migrationBuilder.DropColumn(
                name: "attendance",
                table: "Tbkoral");

            migrationBuilder.DropColumn(
                name: "committed",
                table: "Tbkoral");

            migrationBuilder.DropColumn(
                name: "excellence",
                table: "Tbkoral");
        }
    }
}
