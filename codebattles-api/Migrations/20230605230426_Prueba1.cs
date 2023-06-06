using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace codebattle_api.Migrations
{
    /// <inheritdoc />
    public partial class Prueba1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GameModeId",
                table: "Step");

            migrationBuilder.AddColumn<int>(
                name: "CurrentStep",
                table: "Participant",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentStep",
                table: "Participant");

            migrationBuilder.AddColumn<int>(
                name: "GameModeId",
                table: "Step",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
