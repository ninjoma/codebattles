using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace codebattle_api.Migrations
{
    /// <inheritdoc />
    public partial class ChangedValoration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Validations_Step_StepId",
                table: "Validations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Validations",
                table: "Validations");

            migrationBuilder.RenameTable(
                name: "Validations",
                newName: "Validation");

            migrationBuilder.RenameIndex(
                name: "IX_Validations_StepId",
                table: "Validation",
                newName: "IX_Validation_StepId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Validation",
                table: "Validation",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Validation_Step_StepId",
                table: "Validation",
                column: "StepId",
                principalTable: "Step",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Validation_Step_StepId",
                table: "Validation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Validation",
                table: "Validation");

            migrationBuilder.RenameTable(
                name: "Validation",
                newName: "Validations");

            migrationBuilder.RenameIndex(
                name: "IX_Validation_StepId",
                table: "Validations",
                newName: "IX_Validations_StepId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Validations",
                table: "Validations",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Validations_Step_StepId",
                table: "Validations",
                column: "StepId",
                principalTable: "Step",
                principalColumn: "Id");
        }
    }
}
