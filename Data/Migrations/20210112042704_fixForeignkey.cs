using Microsoft.EntityFrameworkCore.Migrations;

namespace TractionTools.Data.Migrations
{
    public partial class fixForeignkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_UserIngredients_UserIngredientUserId_UserIngredientIngredientId",
                table: "Ingredients");

            migrationBuilder.DropIndex(
                name: "IX_Ingredients_UserIngredientUserId_UserIngredientIngredientId",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "UserIngredientIngredientId",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "UserIngredientUserId",
                table: "Ingredients");

            migrationBuilder.CreateIndex(
                name: "IX_UserIngredients_IngredientId",
                table: "UserIngredients",
                column: "IngredientId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserIngredients_Ingredients_IngredientId",
                table: "UserIngredients",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserIngredients_Ingredients_IngredientId",
                table: "UserIngredients");

            migrationBuilder.DropIndex(
                name: "IX_UserIngredients_IngredientId",
                table: "UserIngredients");

            migrationBuilder.AddColumn<int>(
                name: "UserIngredientIngredientId",
                table: "Ingredients",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserIngredientUserId",
                table: "Ingredients",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_UserIngredientUserId_UserIngredientIngredientId",
                table: "Ingredients",
                columns: new[] { "UserIngredientUserId", "UserIngredientIngredientId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_UserIngredients_UserIngredientUserId_UserIngredientIngredientId",
                table: "Ingredients",
                columns: new[] { "UserIngredientUserId", "UserIngredientIngredientId" },
                principalTable: "UserIngredients",
                principalColumns: new[] { "UserId", "IngredientId" },
                onDelete: ReferentialAction.Restrict);
        }
    }
}
