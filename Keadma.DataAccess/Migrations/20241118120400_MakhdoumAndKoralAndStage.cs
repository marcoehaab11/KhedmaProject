using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Keadma.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class MakhdoumAndKoralAndStage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBMakhdoum",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBMakhdoum", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBTheStage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    StartFrom = table.Column<DateOnly>(type: "date", nullable: true),
                    EndFrom = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBTheStage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbkoral",
                columns: table => new
                {
                    MakhdoumID = table.Column<int>(type: "int", nullable: false),
                    StageID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbkoral", x => new { x.MakhdoumID, x.StageID });
                    table.ForeignKey(
                        name: "FK_Tbkoral_TBMakhdoum_MakhdoumID",
                        column: x => x.MakhdoumID,
                        principalTable: "TBMakhdoum",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tbkoral_TBTheStage_StageID",
                        column: x => x.StageID,
                        principalTable: "TBTheStage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tbkoral_StageID",
                table: "Tbkoral",
                column: "StageID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbkoral");

            migrationBuilder.DropTable(
                name: "TBMakhdoum");

            migrationBuilder.DropTable(
                name: "TBTheStage");
        }
    }
}
