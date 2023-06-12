using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace codebattle_api.Migrations
{
    /// <inheritdoc />
    public partial class MejorasFuncionalidadBatallas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Step_GameMode_GameModeId",
                table: "Step");

            migrationBuilder.DropIndex(
                name: "IX_Step_GameModeId",
                table: "Step");

            migrationBuilder.AddColumn<int>(
                name: "Judge0Id",
                table: "Language",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "GameStep",
                columns: table => new
                {
                    GamesId = table.Column<int>(type: "integer", nullable: false),
                    StepsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameStep", x => new { x.GamesId, x.StepsId });
                    table.ForeignKey(
                        name: "FK_GameStep_Game_GamesId",
                        column: x => x.GamesId,
                        principalTable: "Game",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameStep_Step_StepsId",
                        column: x => x.StepsId,
                        principalTable: "Step",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameStep_StepsId",
                table: "GameStep",
                column: "StepsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameStep");

            migrationBuilder.DropColumn(
                name: "Judge0Id",
                table: "Language");

            migrationBuilder.CreateIndex(
                name: "IX_Step_GameModeId",
                table: "Step",
                column: "GameModeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Step_GameMode_GameModeId",
                table: "Step",
                column: "GameModeId",
                principalTable: "GameMode",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
