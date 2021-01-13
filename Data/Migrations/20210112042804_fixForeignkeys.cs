using Microsoft.EntityFrameworkCore.Migrations;

namespace TractionTools.Data.Migrations
{
    public partial class fixForeignkeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserIngredients",
                table: "UserIngredients");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserIngredients",
                table: "UserIngredients",
                columns: new[] { "UserId", "IngredientId", "RecipeId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserIngredients",
                table: "UserIngredients");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserIngredients",
                table: "UserIngredients",
                columns: new[] { "UserId", "IngredientId" });
        }
    }
}
