using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace codebattle_api.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Validation_Step_StepId",
                table: "Validation");

            migrationBuilder.AlterColumn<int>(
                name: "StepId",
                table: "Validation",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Validation_Step_StepId",
                table: "Validation",
                column: "StepId",
                principalTable: "Step",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Validation_Step_StepId",
                table: "Validation");

            migrationBuilder.AlterColumn<int>(
                name: "StepId",
                table: "Validation",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Validation_Step_StepId",
                table: "Validation",
                column: "StepId",
                principalTable: "Step",
                principalColumn: "Id");
        }
    }
}
