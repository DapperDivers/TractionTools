using Microsoft.EntityFrameworkCore.Migrations;

namespace TractionTools.Data.Migrations
{
    public partial class removeDateTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "User",
                table: "UserIngredient",
                newName: "UserId");

            migrationBuilder.AddColumn<int>(
                name: "RecipeId",
                table: "UserIngredient",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UserIngredient_RecipeId",
                table: "UserIngredient",
                column: "RecipeId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserIngredient_Recipes_RecipeId",
                table: "UserIngredient",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserIngredient_Recipes_RecipeId",
                table: "UserIngredient");

            migrationBuilder.DropIndex(
                name: "IX_UserIngredient_RecipeId",
                table: "UserIngredient");

            migrationBuilder.DropColumn(
                name: "RecipeId",
                table: "UserIngredient");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "UserIngredient",
                newName: "User");
        }
    }
}
