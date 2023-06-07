using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace codebattle_api.Migrations
{
    /// <inheritdoc />
    public partial class LanguageValidator : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Validator",
                table: "Language",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Validator",
                table: "Language");
        }
    }
}
