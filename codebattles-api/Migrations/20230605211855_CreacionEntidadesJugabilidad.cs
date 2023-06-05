using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace codebattle_api.Migrations
{
    /// <inheritdoc />
    public partial class CreacionEntidadesJugabilidad : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Result",
                table: "Step");

            migrationBuilder.RenameColumn(
                name: "Language",
                table: "Game",
                newName: "LanguageId");

            migrationBuilder.AddColumn<string>(
                name: "BoilerPlate",
                table: "Step",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Step",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "Step",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Step",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Language",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Language", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Result",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Value = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Result", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ResultStep",
                columns: table => new
                {
                    ResultsId = table.Column<int>(type: "integer", nullable: false),
                    StepsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResultStep", x => new { x.ResultsId, x.StepsId });
                    table.ForeignKey(
                        name: "FK_ResultStep_Result_ResultsId",
                        column: x => x.ResultsId,
                        principalTable: "Result",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResultStep_Step_StepsId",
                        column: x => x.StepsId,
                        principalTable: "Step",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Step_LanguageId",
                table: "Step",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Game_LanguageId",
                table: "Game",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_ResultStep_StepsId",
                table: "ResultStep",
                column: "StepsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Game_Language_LanguageId",
                table: "Game",
                column: "LanguageId",
                principalTable: "Language",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Step_Language_LanguageId",
                table: "Step",
                column: "LanguageId",
                principalTable: "Language",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Game_Language_LanguageId",
                table: "Game");

            migrationBuilder.DropForeignKey(
                name: "FK_Step_Language_LanguageId",
                table: "Step");

            migrationBuilder.DropTable(
                name: "Language");

            migrationBuilder.DropTable(
                name: "ResultStep");

            migrationBuilder.DropTable(
                name: "Result");

            migrationBuilder.DropIndex(
                name: "IX_Step_LanguageId",
                table: "Step");

            migrationBuilder.DropIndex(
                name: "IX_Game_LanguageId",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "BoilerPlate",
                table: "Step");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Step");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "Step");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Step");

            migrationBuilder.RenameColumn(
                name: "LanguageId",
                table: "Game",
                newName: "Language");

            migrationBuilder.AddColumn<string>(
                name: "Result",
                table: "Step",
                type: "text",
                nullable: true);
        }
    }
}
