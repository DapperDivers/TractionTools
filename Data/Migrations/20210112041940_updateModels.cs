using Microsoft.EntityFrameworkCore.Migrations;

namespace TractionTools.Data.Migrations
{
    public partial class updateModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserIngredient_Ingredients_IngredientId",
                table: "UserIngredient");

            migrationBuilder.DropForeignKey(
                name: "FK_UserIngredient_Recipes_RecipeId",
                table: "UserIngredient");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserIngredient",
                table: "UserIngredient");

            migrationBuilder.RenameTable(
                name: "UserIngredient",
                newName: "UserIngredients");

            migrationBuilder.RenameIndex(
                name: "IX_UserIngredient_RecipeId",
                table: "UserIngredients",
                newName: "IX_UserIngredients_RecipeId");

            migrationBuilder.RenameIndex(
                name: "IX_UserIngredient_IngredientId",
                table: "UserIngredients",
                newName: "IX_UserIngredients_IngredientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserIngredients",
                table: "UserIngredients",
                columns: new[] { "UserId", "IngredientId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserIngredients_Ingredients_IngredientId",
                table: "UserIngredients",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserIngredients_Recipes_RecipeId",
                table: "UserIngredients",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserIngredients_Ingredients_IngredientId",
                table: "UserIngredients");

            migrationBuilder.DropForeignKey(
                name: "FK_UserIngredients_Recipes_RecipeId",
                table: "UserIngredients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserIngredients",
                table: "UserIngredients");

            migrationBuilder.RenameTable(
                name: "UserIngredients",
                newName: "UserIngredient");

            migrationBuilder.RenameIndex(
                name: "IX_UserIngredients_RecipeId",
                table: "UserIngredient",
                newName: "IX_UserIngredient_RecipeId");

            migrationBuilder.RenameIndex(
                name: "IX_UserIngredients_IngredientId",
                table: "UserIngredient",
                newName: "IX_UserIngredient_IngredientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserIngredient",
                table: "UserIngredient",
                columns: new[] { "UserId", "IngredientId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserIngredient_Ingredients_IngredientId",
                table: "UserIngredient",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserIngredient_Recipes_RecipeId",
                table: "UserIngredient",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
