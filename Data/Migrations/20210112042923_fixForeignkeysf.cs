using Microsoft.EntityFrameworkCore.Migrations;

namespace TractionTools.Data.Migrations
{
    public partial class fixForeignkeysf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserIngredients",
                table: "UserIngredients");

            migrationBuilder.DropIndex(
                name: "IX_UserIngredients_IngredientId",
                table: "UserIngredients");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserIngredients",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserIngredients",
                table: "UserIngredients",
                columns: new[] { "IngredientId", "RecipeId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserIngredients",
                table: "UserIngredients");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserIngredients",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserIngredients",
                table: "UserIngredients",
                columns: new[] { "UserId", "IngredientId", "RecipeId" });

            migrationBuilder.CreateIndex(
                name: "IX_UserIngredients_IngredientId",
                table: "UserIngredients",
                column: "IngredientId");
        }
    }
}
